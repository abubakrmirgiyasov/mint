namespace Mint.Domain.Exceptions;

public class ContentNotFoundException : Exception
{
	public ContentNotFoundException(string message) 
		: base(message) { }
}
