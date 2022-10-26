using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class CategoryManager
{
    public CategoryViewModel FormingViewModel(Category category)
    {
        return new CategoryViewModel()
        {
            Id = category.Id,
            Name = category.Name,
            Brands = category.Brands!
                .Select(x => x.Name)
                .ToList()
        };
    }
}
