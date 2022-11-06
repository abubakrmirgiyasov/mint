using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Brand
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(32, ErrorMessage = "Перевышено макс. длина строки (32).")]
    public string Name { get; set; } = "";

    public ICollection<Category>? Categories { get; set; }

    public ICollection<Photo>? Photos { get; set; }
}
