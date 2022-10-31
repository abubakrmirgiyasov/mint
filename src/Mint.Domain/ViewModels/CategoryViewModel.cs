using Mint.Domain.BindingModels;

namespace Mint.Domain.ViewModels;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public List<BrandViewModel> Brands { get; set; } = null!;
}
