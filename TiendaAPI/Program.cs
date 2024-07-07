using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TiendaAPI.Data;
using TiendaAPI.Interfaces;
using TiendaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200") // Reemplaza con la URL de tu frontend Angular
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Ya no validamos el emisor ni la audiencia
            ValidateAudience = false,
            ValidateLifetime = true, // Validar la expiración del token
            ValidateIssuerSigningKey = true, // Validar la firma del token
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });

// Registro de servicios CRUD para Tienda, Articulo y Cliente
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITiendaService, TiendaService>(); // <-- Asegúrate de tener estos servicios implementados
builder.Services.AddScoped<IArticuloService, ArticuloService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            // Aquí puedes personalizar el manejo de diferentes tipos de excepciones
            var errorResponse = new
            {
                statusCode = context.Response.StatusCode,
                message = contextFeature.Error.Message
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    });
});

app.UseHttpsRedirection();
app.UseAuthentication(); // Autenticación antes de Autorización
app.UseAuthorization();

app.MapControllers();

app.Run();
