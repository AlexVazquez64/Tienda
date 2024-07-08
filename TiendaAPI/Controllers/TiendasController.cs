using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TiendasController : ControllerBase
{
    private readonly ITiendaService _tiendaService;
    private readonly IArticuloService _articuloService; // Para obtener artículos por tienda

    public TiendasController(ITiendaService tiendaService, IArticuloService articuloService)
    {
        _tiendaService = tiendaService;
        _articuloService = articuloService;
    }

    // GET: api/tiendas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tiendas>>> GetTiendas()
    {
        var tiendas = await _tiendaService.GetAllAsync();
        return Ok(tiendas);
    }

    // GET: api/tiendas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tiendas>> GetTienda(int id)
    {
        var tienda = await _tiendaService.GetByIdAsync(id);
        if (tienda == null)
            return NotFound();

        return Ok(tienda);
    }

    // GET: api/tiendas/5/articulos
    [HttpGet("{id}/articulos")]
    public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulosPorTienda(int id)
    {
        var articulos = await _articuloService.GetByTiendaIdAsync(id); // Método para obtener artículos por tienda (debes implementarlo en ArticuloService)
        return Ok(articulos);
    }

    // POST: api/tiendas
    [HttpPost]
    public async Task<ActionResult<Tiendas>> CreateTienda(Tiendas tienda)
    {
        var createdTienda = await _tiendaService.CreateAsync(tienda);
        return CreatedAtAction(nameof(GetTienda), new { id = createdTienda.Id }, createdTienda);
    }

    // PUT: api/tiendas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTienda(int id, Tiendas tienda)
    {
        if (id != tienda.Id)
            return BadRequest();

        await _tiendaService.UpdateAsync(tienda);
        return NoContent();
    }

    // DELETE: api/tiendas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTienda(int id)
    {
        await _tiendaService.DeleteAsync(id);
        return NoContent();
    }
}
