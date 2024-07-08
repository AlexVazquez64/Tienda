using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TiendaAPI.Exceptions;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService; // Suponiendo que tienes un servicio para obtener usuarios

    public AuthService(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    public async Task<string?> AuthenticateUserAsync(LoginRequest loginRequest)
    {
        var user = await _userService.GetUserByUsernameAsync(loginRequest.Username); // Obtener usuario por nombre de usuario

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
            throw new InvalidCredentialsException("Credenciales inválidas."); // Lanzar excepción si las credenciales son inválidas

        // Autenticación exitosa, generar token JWT
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7), // Token válido por 7 días (ajustable)
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
