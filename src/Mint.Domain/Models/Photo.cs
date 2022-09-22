namespace Mint.Domain.Models;

public class Photo
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = "";

    public string FileExtension { get; set; } = "";

    public double FileSize { get; set; }

    public string FilePath { get; set; } = "";

    public byte[] FileBytes { get; set; } = Array.Empty<byte>();

    public Guid? UserId { get; set; }

    public User? User { get; set; }
}
