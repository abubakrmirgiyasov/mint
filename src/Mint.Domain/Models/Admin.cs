using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Admin
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Фамилия")]
    [MaxLength(100)]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Имя")]
    [MaxLength (100)]
    public string SecondName { get; set; } = "";

    [MaxLength (100)]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Заполните поле Email")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(100)]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Телефон")]
    [DataType(DataType.PhoneNumber)]
    public long Phone { get; set; }

    [Required(ErrorMessage = "Заполните поле Пароль")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Мин. букв 6")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Мин. букв 6")]
    public string ConfirmedPassword { get; set; } = "";

    public int NumOfAttempts { get; set; } = 0;

    public bool IsActive { get; set; } = true;

    public Guid? AddressId { get; set; }

    public Address? Address { get; set; }

    public Guid? RoleId { get; set; }

    public Role? Role { get; set; }

    public ICollection<Photo>? Photos { get; set; }
}
