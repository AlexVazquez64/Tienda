using Microsoft.EntityFrameworkCore;
using TiendaAPI.Entities;

namespace TiendaAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Clientes = Set<Cliente>();
        Tiendas = Set<Tiendas>();
        Articulos = Set<Articulo>();
        Compras = Set<Compra>();
        ArticulosTienda = Set<ArticuloTienda>();
        Usuarios = Set<Usuario>();
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Tiendas> Tiendas { get; set; }
    public DbSet<Articulo> Articulos { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<ArticuloTienda> ArticulosTienda { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relaciones
        modelBuilder.Entity<Compra>()
            .HasKey(c => new { c.ClienteId, c.ArticuloId });
        
        modelBuilder.Entity<Compra>()
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Compras)
            .HasForeignKey(c => c.ClienteId);

        modelBuilder.Entity<Compra>()
            .HasOne(c => c.Articulo)
            .WithMany(c => c.Compras)
            .HasForeignKey(c => c.ArticuloId);

        modelBuilder.Entity<ArticuloTienda>()
            .HasKey(at => new { at.ArticuloId, at.TiendaId });

        modelBuilder.Entity<ArticuloTienda>()
            .HasOne(at => at.Articulo)
            .WithMany(a => a.ArticulosTienda)
            .HasForeignKey(at => at.ArticuloId);

        modelBuilder.Entity<ArticuloTienda>()
            .HasOne(at => at.Tienda)
            .WithMany(t => t.ArticulosTienda)
            .HasForeignKey(at => at.TiendaId);
    }
}
