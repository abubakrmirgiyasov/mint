using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Infrastructure.Services.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();

    Task<Category> GetCategoryByIdAsync(Guid id);

    Task<Category> AddCategoryAsync(CategoryBindingModel category);

    Task<Category> UpdateCategoryAsync(CategoryBindingModel category);

    Task<Category> DeleteCategoryAsync(CategoryBindingModel category);
}
