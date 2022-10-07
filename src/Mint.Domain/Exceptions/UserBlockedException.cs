namespace Mint.Domain.Exceptions;

public class UserBlockedException : Exception
{
	public string HelpLink { get; set; } = "https://google.com";

	public UserBlockedException(string message)
		: base(message) { }
}
