// UserNotFoundException.cs
namespace TiendaAPI.Exceptions;

public class UserNotFoundException : Exception
{
  public UserNotFoundException(string message) : base(message) { }
}
