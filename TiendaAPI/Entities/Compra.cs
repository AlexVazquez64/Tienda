using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities;

public class Compra
{
    [Key]
    public int ClienteId { get; set; }
    [Key]
    public int ArticuloId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.UtcNow;

    // Propiedades de navegación para las entidades relacionadas
    public Cliente Cliente { get; set; }
    public Articulo Articulo { get; set; }
}
