using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Photo
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [MaxLength(60, ErrorMessage = "Макс. длина строки 60")]
    public string FileName { get; set; } = "";

    public string FileExtension { get; set; } = "";

    public double FileSize { get; set; }

    public string FilePath { get; set; } = "";

    public byte[] FileBytes { get; set; } = Array.Empty<byte>();

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public Guid? SubCategoryId { get; set; }

    public SubCategory? SubCategory { get; set; }

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? BrandId { get; set; }

    public Brand? Brand { get; set; }

    public Guid? AdminId { get; set; }

    public Admin? Admin { get; set; }
}
