namespace Mint.Domain.BindingModels;

public class PhotoBindingModel
{
    public Guid Id { get; set; }

    public string? FullName { get; set; }

    public string FileName { get; set; } = "";

    public string FileExtension { get; set; } = "";

    public double FileSize { get; set; }

    public string FilePath { get; set; } = "";

    public byte[] FileBytes { get; set; } = Array.Empty<byte>();

    public Guid? CategoryId { get; set; }

    public Guid? BrandId { get; set; }

    public Guid? SubCategoryId { get; set; }

    public Guid? UserId { get; set; }
}