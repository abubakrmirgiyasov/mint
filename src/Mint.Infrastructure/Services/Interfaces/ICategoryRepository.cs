using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Infrastructure.Services.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();

    Task<Category> GetCategoryByIdAsync(Guid id);
    //Task<Brand> GetBrandByIdAsync(Guid id);

    //Task<Brand> AddBrandAsync(BrandBindingModel brand);

    //Task<string> UpdateBrandAsync(BrandBindingModel brand);

    //Task<Brand> DeleteBrandAsync(BrandBindingModel brand);

    //Task<List<Category>> GetCategoriesAsyn1c();


    //Task<Category> AddCategoryAsync(CategoryBindingModel category);

    //Task<Category> UpdateCategoryAsync(CategoryBindingModel category);

    //Task<Category> DeleteCategoryAsync(CategoryBindingModel category);
}
