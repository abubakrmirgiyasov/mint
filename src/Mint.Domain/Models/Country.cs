using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Country
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string Name { get; set; } = "";

    public ICollection<Address>? Cities { get; set; }
}
