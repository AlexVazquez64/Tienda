using TiendaAPI.Entities;

namespace TiendaAPI.Interfaces;

public interface ITiendaService
{
    Task<IEnumerable<Tienda>> GetAllAsync();
    Task<Tienda?> GetByIdAsync(int id);
    Task<Tienda> CreateAsync(Tienda tienda);
    Task UpdateAsync(Tienda tienda);
    Task DeleteAsync(int id);
}
