namespace Mint.Domain.BindingModels;

public class UserBindingModel
{
    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public string? Ip { get; set; }

    public string Password { get; set; } = "";

    public string ConfirmPassword { get; set; } = "";

    public PhotoBindingModel? Photo { get; set; }
}
