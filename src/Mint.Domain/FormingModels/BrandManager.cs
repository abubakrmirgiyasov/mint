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
                    Photos = brands[i].Photos?.ToList()
                });
            }

            return brandViewModels;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<Brand> FormingBindingModels(List<BrandBindingModel> brandBindindingModels, Guid categoryId)
    {
        try
        {
            var brand = new List<Brand>();

            for (int i = 0; i < brandBindindingModels.Count; i++)
            {
                brand.Add(new Brand()
                {
                    Id = brandBindindingModels[i].Id,
                    Name = brandBindindingModels[i].Name,
                    CategoryId = categoryId,
                    Photos = new List<Photo>(),
                });

                for (int j = 0; j < brandBindindingModels[i].Photos.Count; j++)
                {
                    brand[i].Photos!.Add(new Photo()
                    {
                        BrandId = brand[j].Id,
                        FileName = brandBindindingModels[i].Photos[j].FileName,
                        FileExtension = brandBindindingModels[i].Photos[j].FileExtension,
                        FilePath = brandBindindingModels[i].Photos[j].FilePath,
                        FileSize = brandBindindingModels[i].Photos[j].FileSize,
                        FileBytes = brandBindindingModels[i].Photos[j].FileBytes,
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
