using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(32, ErrorMessage = "Перевышено макс. длина строки (32).")]
    public string Name { get; set; } = "";

    public Guid? BrandId { get; set; }

    public Brand? Brand { get; set; }

    public ICollection<SubCategory>? SubCategories { get; set; }

    public ICollection<Photo>? Photos { get; set; }
}
