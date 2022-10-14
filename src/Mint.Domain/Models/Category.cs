using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(32, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string Name { get; set; } = "";

    public ICollection<Photo>? Photos { get; set; }
}
