using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class BrandManager
{
    public List<BrandViewModel> FormingViewModels(List<Brand> brands)
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

    public List<Brand> FormingBindingModels(List<BrandBindingModel> breands)
    {
        return new List<Brand>()
        {
            
        };
    }
}
