using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Domain.ViewModels;

public class CategoryViewModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public List<SubCategoryViewModel>? SubCategories { get; set; }

    public List<PhotoBindingModel>? Photos { get; set; }
}
