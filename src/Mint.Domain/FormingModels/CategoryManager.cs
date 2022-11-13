using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class CategoryManager
{
    public List<CategoryViewModel> FormingViewModels(List<Category> categories)
    {
        try
        {
            var categoryViewModels = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                categoryViewModels.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    SubCategories = new SubCategoryManager().FormingViewModels(category.SubCategories?.ToList()),
                    Photos = new PhotoManager().FormingViewModels(category.Photos?.ToList()),
                });
            }
            return categoryViewModels;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<Category> FormingBindingModels(List<CategoryBindingModel> category)
    {
        try
        {
            var categories = new List<Category>();

            for (int i = 0; i < category.Count; i++)
            {
                categories.Add(new Category
                {
                    Name = category[i].Name,
                });
            }
            return categories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
