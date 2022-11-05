using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Role
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(32, ErrorMessage = "Перевышено макс. длина строки (32).")]
    public string Name { get; set; } = "";

    public ICollection<Admin>? Admins { get; set; }

    public ICollection<User>? Users { get; set; }
}
