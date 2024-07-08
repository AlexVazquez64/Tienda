using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Entities;
using TiendaAPI.Exceptions;
using TiendaAPI.Interfaces;

namespace Tienda.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(LoginRequest loginRequest)
    {
        try
        {
            var token = await _authService.AuthenticateUserAsync(loginRequest);
            return Ok(token);
        }
        catch (InvalidCredentialsException ex)
        {
            return Unauthorized(new { message = ex.Message }); // Devolver 401 Unauthorized con mensaje de error
        }
    }
}
