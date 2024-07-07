using Microsoft.EntityFrameworkCore;
using TiendaAPI.Entities;

namespace TiendaAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Tienda> Tiendas { get; set; }
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<ArticuloTienda> ArticulosTienda { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar las relaciones entre las entidades
        modelBuilder.Entity<Compra>()
            .HasKey(c => new { c.ClienteId, c.ArticuloId });

        modelBuilder.Entity<ArticuloTienda>()
            .HasKey(at => new { at.ArticuloId, at.TiendaId });
    }
}
