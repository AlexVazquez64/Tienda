using TiendaAPI.Entities;

namespace TiendaAPI.Interfaces;

public interface ITiendaService
{
    Task<IEnumerable<Tiendas>> GetAllAsync();
    Task<Tiendas?> GetByIdAsync(int id);
    Task<Tiendas> CreateAsync(Tiendas tienda);
    Task UpdateAsync(Tiendas tienda);
    Task DeleteAsync(int id);
}
