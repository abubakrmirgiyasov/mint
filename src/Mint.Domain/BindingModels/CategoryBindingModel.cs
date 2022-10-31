namespace Mint.Domain.BindingModels;

public class CategoryBindingModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public List<BrandBindingModel> Brands { get; set; } = null!; 
}
