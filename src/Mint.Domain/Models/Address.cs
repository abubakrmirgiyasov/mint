using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Address
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Город")]
    [MaxLength(100, ErrorMessage = "Перевышено макс. длина строки (100).")]
    public string City { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Улица")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Street { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Дом")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Home { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Описание")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Description { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Почтовый индекс")]
    [DataType(DataType.PostalCode)]
    public int PostCode { get; set; }

    public Guid? CountryId { get; set; }

    public Country? Country { get; set; }

    public ICollection<Admin>? Admins { get; set; }

    public ICollection<User>? Users { get; set; }
}
