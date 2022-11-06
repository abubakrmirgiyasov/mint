using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class CategoryManager
{
    //public List<CategoryViewModel> FormingViewModels(List<Category> categories)
    //{
    //    var categoryViewModels = new List<CategoryViewModel>();

    //    foreach (var category in categories)
    //    {
    //        categoryViewModels.Add(new CategoryViewModel()
    //        {
    //            Id = category.Id,
    //            Name = category.Name,
    //            Brands = new BrandManager().FormingViewModels(category.Brands!.ToList()),
    //        });
    //    }

    //    return categoryViewModels;
    //}

    //public CategoryViewModel FormingViewModel(Category category)
    //{
    //    var categoryViewModel = new CategoryViewModel
    //    {
    //        Id = category.Id,
    //        Name = category.Name,
    //        Brands = new BrandManager().FormingViewModels(category.Brands!.ToList())
    //    };
    //    return categoryViewModel;
    //}

    //public Category FormingBindingModel(CategoryBindingModel category)
    //{
    //    var newCategory = new Category
    //    {
    //        Id = category.Id,
    //        Name = category.Name
    //    };

    //    newCategory.Brands = new List<Brand>();

    //    for (int i = 0; i < category.Brands.Count; i++)
    //    {
    //        newCategory.Brands!.Add(new Brand()
    //        {
    //            Id = category.Brands[i].Id,
    //            Name = category.Brands[i].Name,
    //            Photos = new PhotoManager().FormingBindingModel(category.Brands[i].Photos),
    //        });
    //    }

    //    return newCategory;
    //}
}
