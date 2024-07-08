// InvalidCredentialsException.cs
namespace TiendaAPI.Exceptions;

public class InvalidCredentialsException : Exception
{
  public InvalidCredentialsException(string message) : base(message) { }
}
