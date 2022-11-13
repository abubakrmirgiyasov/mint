using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class BrandManager
{
    public List<BrandViewModel> FormingViewModels(List<Brand> brands)
    {
        try
        {
            var brandViewModels = new List<BrandViewModel>();

            for (int i = 0; i < brands.Count; i++)
            {
                brandViewModels.Add(new BrandViewModel
                {
                    Id = brands[i].Id,
                    Name = brands[i].Name,
                    Categories = new CategoryManager().FormingViewModels(brands[i].Categories!.ToList()),
                    Photos = new PhotoManager().FormingViewModels(brands[i].Photos?.ToList()),
                });
            }

            return brandViewModels;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public BrandViewModel FormingViewModel(Brand? brand)
    {
        try
        {
            if (brand != null)
            {
                var brandViewModel = new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Categories = new CategoryManager().FormingViewModels(brand.Categories!.ToList())
                };

                return brandViewModel;
            }
            return null!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Brand FormingBindingModel(BrandBindingModel brandBindindingModel)
    {
        try
        {
            var brand = new Brand
            {
                Id = brandBindindingModel.Id,
                Name = brandBindindingModel.Name,
                Photos = new PhotoManager().FormingBindingModel(brandBindindingModel.Photos!.ToList()),
                Categories = new List<Category>(),
            };

            for (int i = 0; i < brandBindindingModel.Categories.Count; i++)
            {
                brand.Categories.Add(new Category
                {
                    Name = brandBindindingModel.Categories[i].Name,
                    BrandId = brandBindindingModel.Categories[i].Id,
                    SubCategories = new List<SubCategory>(),
                    Photos = new PhotoManager().FormingBindingModel(brandBindindingModel.Categories[i].Photos),
                });

                for (int j = 0; j < brandBindindingModel.Categories[i].SubCategories.Count; j++)
                {
                    brand.Categories.ToList()[i].SubCategories!.Add(new SubCategory
                    {
                        Name = brandBindindingModel.Categories[i].SubCategories[j].Name,
                        CategoryId = brandBindindingModel.Categories[i].SubCategories[j].CategoryId,
                        Photos = new PhotoManager().FormingBindingModel(brandBindindingModel.Categories[i].SubCategories[j].Photos),
                    });
                }
            }

            return brand;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
