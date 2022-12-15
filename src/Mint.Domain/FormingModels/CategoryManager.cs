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
                    Brands = new BrandManager().FormingViewModels(category.Brands!.ToList()),
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

    public CategoryViewModel FormingViewModel(Category category)
    {
        try
        {
            var categoryViewModel = new CategoryViewModel();

            for (int i = 0; i < category.Photos!.Count; i++)
            {
                categoryViewModel.Photos!.Add(new PhotoBindingModel()
                {
                    Id = category.Photos.ToList()[i].Id,
                    FileExtension = category.Photos.ToList()[i].FileExtension,
                    FileBytes = category.Photos.ToList()[i].FileBytes,
                    FileSize = category.Photos.ToList()[i].FileSize,
                    FileName = category.Photos.ToList()[i].FileName,
                    FilePath = category.Photos.ToList()[i].FilePath,
                    FullName = category.Photos.ToList()[i].FullName,
                });
            }

            for (int i = 0; i < category.Brands!.Count; i++)
            {
                categoryViewModel.Brands = new List<BrandViewModel>()
                {
                    new BrandViewModel()
                    {
                        Id = category.Brands.ToList()[i].Id,
                        Name = category.Brands.ToList()[i].Name,
                    }
                };

                for (int j = 0; j < category.Brands.ToList()[i].Photos!.Count; j++)
                {
                    categoryViewModel.Brands.ToList()[i].Photos = new List<PhotoBindingModel>()
                    {
                        new PhotoBindingModel()
                        {
                            Id = category.Brands.ToList()[i].Photos!.ToList()[j].Id,
                            FullName = category.Brands.ToList()[i].Photos!.ToList()[j].FullName,
                            FileName = category.Brands.ToList()[i].Photos!.ToList()[j].FileName,
                            FileExtension = category.Brands.ToList()[i].Photos!.ToList()[j].FileExtension,
                            FileBytes = category.Brands.ToList()[i].Photos!.ToList()[j].FileBytes,
                            FileSize = category.Brands.ToList()[i].Photos!.ToList()[j].FileSize,
                            FilePath = category.Brands.ToList()[i].Photos!.ToList()[j].FilePath,
                        }
                    };
                }
            }

            for (int i = 0; i < category.SubCategories!.Count; i++)
            {
                categoryViewModel.SubCategories = new List<SubCategoryViewModel>()
                {
                    new SubCategoryViewModel()
                    {
                        Id = category.SubCategories.ToList()[i].Id,
                        Name = category.SubCategories.ToList()[i].Name,
                    }
                };

                for (int j = 0; j < category.SubCategories.ToList()[i].Photos!.Count; j++)
                {
                    categoryViewModel.SubCategories.ToList()[i].Photos = new List<PhotoBindingModel>()
                    {
                        new PhotoBindingModel()
                        {
                            Id = category.SubCategories.ToList()[i].Photos!.ToList()[j].Id,
                            FullName = category.SubCategories.ToList()[i].Photos!.ToList()[j].FullName,
                            FileName = category.SubCategories.ToList()[i].Photos!.ToList()[j].FileName,
                            FileExtension = category.SubCategories.ToList()[i].Photos!.ToList()[j].FileExtension,
                            FileBytes = category.SubCategories.ToList()[i].Photos!.ToList()[j].FileBytes,
                            FileSize = category.SubCategories.ToList()[i].Photos!.ToList()[j].FileSize,
                            FilePath = category.SubCategories.ToList()[i].Photos!.ToList()[j].FilePath,
                        }
                    };
                }
            }

            categoryViewModel.Id = category.Id;
            categoryViewModel.Name = category.Name;

            return categoryViewModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
