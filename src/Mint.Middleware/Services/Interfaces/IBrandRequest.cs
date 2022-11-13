using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Middleware.Services.Interfaces;

public interface IBrandRequest
{
    Task<List<Brand>> GetBrandsAsync();

    Task<Brand> GetBrandByIdAsync(Guid id);

    Task<List<Category>> GetCategoriesAsync();

    Task<BrandBindingModel> AddBrandAsync(BrandBindingModel brand);

    Task<BrandBindingModel> UpdateBrandAsync(BrandBindingModel category);
}
