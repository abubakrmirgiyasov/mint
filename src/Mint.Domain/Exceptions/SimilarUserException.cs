namespace Mint.Domain.Exceptions;

public class SimilarUserException : Exception
{
	public SimilarUserException(string message) 
		: base (message) { }
}
