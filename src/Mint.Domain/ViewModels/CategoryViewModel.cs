using Mint.Domain.BindingModels;

namespace Mint.Domain.ViewModels;

public class CategoryViewModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public List<BrandViewModel>? Brands { get; set; }

    public List<SubCategoryViewModel>? SubCategories { get; set; }

    public List<PhotoBindingModel>? Photos { get; set; }
}
