using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities;

public class Articulo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    public decimal Precio { get; set; }

    [MaxLength(255)]
    public string? Imagen { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Propiedades de navegación para las relaciones muchos a muchos
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    public ICollection<ArticuloTienda> ArticulosTienda { get; set; } = new List<ArticuloTienda>();

    public Articulo()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
