using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Direccion { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Propiedad de navegación para las compras del cliente (Relación 1 a Muchos)
    public ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public Cliente()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}
