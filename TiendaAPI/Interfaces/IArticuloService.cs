using TiendaAPI.Entities;

namespace TiendaAPI.Interfaces;

public interface IArticuloService
{
    Task<IEnumerable<Articulo>> GetAllAsync();
    Task<Articulo?> GetByIdAsync(int id);
    Task<Articulo> CreateAsync(Articulo articulo);
    Task UpdateAsync(Articulo articulo);
    Task DeleteAsync(int id);
    Task<IEnumerable<Articulo>> GetByTiendaIdAsync(int tiendaId);
}
