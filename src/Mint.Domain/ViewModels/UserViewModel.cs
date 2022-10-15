namespace Mint.Domain.ViewModels;

public class UserViewModel
{
    public Guid? Id { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public string Password { get; set; } = "";

    public bool RememberMe { get; set; } = false;

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Role { get; set; }
}
