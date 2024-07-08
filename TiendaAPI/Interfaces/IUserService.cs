using TiendaAPI.Entities;

namespace TiendaAPI.Interfaces;

public interface IUserService
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario?> GetUserByUsernameAsync(string username);
    Task<Usuario> CreateAsync(Usuario usuario, string password);
    Task UpdateAsync(Usuario usuario, string? newPassword = null); // Permitir actualizar la contraseña opcionalmente
    Task DeleteAsync(int id);
}
