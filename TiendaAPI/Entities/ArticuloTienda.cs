using System.ComponentModel.DataAnnotations;

namespace TiendaAPI.Entities;

public class ArticuloTienda
{
    [Key]
    public int ArticuloId { get; set; }
    [Key]
    public int TiendaId { get; set; }

    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public int Stock { get; set; }

    // Propiedades de navegación para las entidades relacionadas
    public Articulo Articulo { get; set; }
    public Tienda Tienda { get; set; }
}
