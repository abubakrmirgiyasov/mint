using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mint.Domain.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Фамилия")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Имя")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string SecondName { get; set; } = "";

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? LastName { get; set; }

    public bool IsActiveAccount { get; set; } = true;

    public int NumOfAttempts { get; set; } = 0;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Заполните поле Почта")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Телефон")]
    [DataType(DataType.PhoneNumber)]
    public long Phone { get; set; }

    [Required(ErrorMessage = "Заполните поле Пароль")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Минимальное кол. букв 6")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Заполните поле Повторите Пароль")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Минимальное кол. букв 6")]
    [MaxLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string ConfirmedPassword { get; set; } = "";

    public string Ip { get; set; } = "";

    public Guid? RoleId { get; set; }

    public Role? Role { get; set; }

    public ICollection<Photo>? Photos { get; set; }
}
