using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class SubCategory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните все поля корректно")]
    [MaxLength(60, ErrorMessage = "Макс. длина строки 60")]
    public string Name { get; set; } = "";

    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public ICollection<Photo>? Photos { get; set; }
}
