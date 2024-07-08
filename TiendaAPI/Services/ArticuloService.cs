using System.Linq;
using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Services;

public class ArticuloService : IArticuloService
{
    private readonly AppDbContext _context;

    public ArticuloService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Articulo>> GetAllAsync()
    {
        return await _context.Articulos.ToListAsync();
    }

    public async Task<Articulo?> GetByIdAsync(int id)
    {
        return await _context.Articulos.FindAsync(id);
    }

    public async Task<Articulo> CreateAsync(Articulo articulo)
    {
        _context.Articulos.Add(articulo);
        await _context.SaveChangesAsync();
        return articulo;
    }

    public async Task UpdateAsync(Articulo articulo)
    {
        _context.Entry(articulo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var articulo = await _context.Articulos.FindAsync(id);
        if (articulo != null)
        {
            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Articulo>> GetByTiendaIdAsync(int tiendaId)
    {
        return await _context
            .Articulos.Where(a => a.ArticulosTienda.Any(at => at.TiendaId == tiendaId))
            .ToListAsync();
    }
}
