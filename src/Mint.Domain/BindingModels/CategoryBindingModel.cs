namespace Mint.Domain.BindingModels;

public class CategoryBindingModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public List<BrandBindingModel>? Brands { get; set; }

    public List<SubCategoryBindingModel>? SubCategories { get; set; }

    public List<PhotoBindingModel>? Photos { get; set; }
}
