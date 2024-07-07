using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities;

public class Tienda
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Sucursal { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Propiedad de navegación para los artículos en la tienda (Relación 1 a Muchos)
    public ICollection<ArticuloTienda> ArticulosTienda { get; set; } = new List<ArticuloTienda>();

    public Tienda()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
