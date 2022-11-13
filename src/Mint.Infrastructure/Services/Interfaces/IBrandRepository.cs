using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Infrastructure.Services.Interfaces;

public interface IBrandRepository
{
    Task<List<Brand>> GetBrandsAsync();

    Task<Brand> GetBrandByIdAsync(Guid id);

    Task<List<Category>> GetCategoriesAsync();

    Task<Category> AddCategoryAsync(CategoryBindingModel category);

    Task<Brand> UpdateCategoryAsync(CategoryBindingModel category);

    Task<string> UpdateBrandAsync(BrandBindingModel brand);

    Task<Category> DeleteCategoryAsync(CategoryBindingModel category);
}
