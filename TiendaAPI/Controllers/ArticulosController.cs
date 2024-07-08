using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticulosController : ControllerBase
{
    private readonly IArticuloService _articuloService;

    public ArticulosController(IArticuloService articuloService)
    {
        _articuloService = articuloService;
    }

    // GET: api/articulos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
    {
        var articulos = await _articuloService.GetAllAsync();
        return Ok(articulos);
    }

    // GET: api/articulos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Articulo>> GetArticulo(int id)
    {
        var articulo = await _articuloService.GetByIdAsync(id);
        if (articulo == null)
            return NotFound();

        return Ok(articulo);
    }

    // POST: api/articulos
    [HttpPost]
    public async Task<ActionResult<Articulo>> CreateArticulo(Articulo articulo)
    {
        var createdArticulo = await _articuloService.CreateAsync(articulo);
        return CreatedAtAction(
            nameof(GetArticulo),
            new { id = createdArticulo.Id },
            createdArticulo
        );
    }

    // PUT: api/articulos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticulo(int id, Articulo articulo)
    {
        if (id != articulo.Id)
            return BadRequest();

        await _articuloService.UpdateAsync(articulo);
        return NoContent();
    }

    // DELETE: api/articulos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticulo(int id)
    {
        await _articuloService.DeleteAsync(id);
        return NoContent();
    }
}
