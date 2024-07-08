using TiendaAPI.Entities;

namespace TiendaAPI.Interfaces;

public interface IAuthService
{
    Task<string?> AuthenticateUserAsync(LoginRequest loginRequest);
}
