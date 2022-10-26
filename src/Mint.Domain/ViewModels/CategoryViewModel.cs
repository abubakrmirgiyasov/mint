namespace Mint.Domain.ViewModels;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public List<string> Brands { get; set; } = null!;
}
