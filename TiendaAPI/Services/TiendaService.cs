using System.Linq;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Services;

public class TiendaService : ITiendaService
{
    private readonly AppDbContext _context;

    public TiendaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tiendas>> GetAllAsync()
    {
        return await _context.Tiendas.ToListAsync();
    }

    public async Task<Tiendas?> GetByIdAsync(int id)
    {
        return await _context.Tiendas.FindAsync(id);
    }

    public async Task<Tiendas> CreateAsync(Tiendas tienda)
    {
        _context.Tiendas.Add(tienda);
        await _context.SaveChangesAsync();
        return tienda;
    }

    public async Task UpdateAsync(Tiendas tienda)
    {
        _context.Entry(tienda).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tienda = await _context.Tiendas.FindAsync(id);
        if (tienda != null)
        {
            _context.Tiendas.Remove(tienda);
            await _context.SaveChangesAsync();
        }
    }
}
