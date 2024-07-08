using Microsoft.EntityFrameworkCore;
using TiendaAPI.Data;
using TiendaAPI.Entities;
using TiendaAPI.Interfaces;

namespace TiendaAPI.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario?> GetUserByUsernameAsync(string username)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<Usuario> CreateAsync(Usuario usuario, string password)
    {
        // Verificar si el nombre de usuario ya existe
        if (await _context.Usuarios.AnyAsync(u => u.Username == usuario.Username))
            throw new ArgumentException("El nombre de usuario ya está en uso.");

        usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task UpdateAsync(Usuario usuario, string? newPassword = null)
    {
        var existingUser = await _context.Usuarios.FindAsync(usuario.Id);

        if (existingUser == null)
            throw new KeyNotFoundException("Usuario no encontrado.");

        existingUser.Username = usuario.Username;

        // Actualizar la contraseña si se proporciona una nueva
        if (!string.IsNullOrEmpty(newPassword))
        {
            existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
