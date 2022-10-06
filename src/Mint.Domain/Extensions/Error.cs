namespace Mint.Domain.Extensions;

public class Error
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Message { get; set; } = "";

    public int StatucCode { get; set; }
}
