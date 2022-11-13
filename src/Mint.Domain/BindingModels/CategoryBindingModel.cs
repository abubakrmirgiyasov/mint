namespace Mint.Domain.BindingModels;

public class CategoryBindingModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";

    public Guid BrandId { get; set; }

    public List<SubCategoryBindingModel> SubCategories { get; set; } = null!;

    public List<PhotoBindingModel> Photos { get; set; } = null!;
}
