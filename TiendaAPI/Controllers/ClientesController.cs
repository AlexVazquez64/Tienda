using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("api/[controller]")] // La ruta será /api/clientes, /api/tiendas, /api/articulos
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    // GET: api/clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        var clientes = await _clienteService.GetAllAsync();
        return Ok(clientes);
    }

    // GET: api/clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> CreateCliente(Cliente cliente)
    {
        var createdCliente = await _clienteService.CreateAsync(cliente);
        return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.Id }, createdCliente);
    }

    // PUT: api/clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id)
            return BadRequest();

        await _clienteService.UpdateAsync(cliente);
        return NoContent();
    }

    // DELETE: api/clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        await _clienteService.DeleteAsync(id);
        return NoContent();
    }
}
