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
                brandViewModels.Add(new BrandViewModel()
                {
                    Id = brands[i].Id,
                    Name = brands[i].Name,
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
                var brandViewModel = new BrandViewModel()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    //Categories = new CategoryManager().FormingViewModels(brand.Categories!.ToList())
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
            //var brand = new Brand()
            //{
            //    Id = brandBindindingModel.Id,
            //    Name = brandBindindingModel.Name,
            //};

            //var brandsPhoto = new List<Photo>();

            //for (int i = 0; i < brandBindindingModel.Photos.Count; i++)
            //{
            //    brandsPhoto.Add(new Photo()
            //    {
            //        Id = brandBindindingModel.Photos[i].Id,
            //        BrandId = brandBindindingModel.Id,
            //        FileName = brandBindindingModel.Photos[i].FileName,
            //        FileSize = brandBindindingModel.Photos[i].FileSize,
            //        FileExtension = brandBindindingModel.Photos[i].FileExtension,
            //        FileBytes = brandBindindingModel.Photos[i].FileBytes,
            //        FilePath = brandBindindingModel.Photos[i].FilePath,
            //    });
            //}
            //brand.Photos = brandsPhoto;

            //for (int i = 0; i < brandBindindingModel.Categories.Count; i++)
            //{
            //    var categoriesPhoto = new List<Photo>();

            //    brand.Categories = new List<Category>
            //    {
            //        new Category()
            //        {
            //            Id = brandBindindingModel.Categories[i].Id,
            //            Name = brandBindindingModel.Categories[i].Name,
            //            BrandId = brandBindindingModel.Categories[i].BrandId,
            //        }
            //    };

            //    for (int j = 0; j < brandBindindingModel.Categories[i].Photos.Count; j++)
            //    {
            //        categoriesPhoto.Add(new Photo()
            //        {
            //            Id = brandBindindingModel.Categories[i].Photos[j].Id,
            //            CategoryId = brandBindindingModel.Categories[j].Id,
            //            FileName = brandBindindingModel.Photos[i].FileName,
            //            FileSize = brandBindindingModel.Photos[i].FileSize,
            //            FileExtension = brandBindindingModel.Photos[i].FileExtension,
            //            FileBytes = brandBindindingModel.Photos[i].FileBytes,
            //            FilePath = brandBindindingModel.Photos[i].FilePath,
            //        });
            //    }
            //    brand.Categories.ToList()[i].Photos = categoriesPhoto;
            //}

            //return brand; 
            return new Brand();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
