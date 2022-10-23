namespace Mint.Domain.BindingModels;

public class PhotoBindingModel
{
    public string FileName { get; set; } = "";

    public string FileExtension { get; set; } = "";

    public double FileSize { get; set; }

    public string FilePath { get; set; } = "";

    public byte[] FileBytes { get; set; } = Array.Empty<byte>();
}