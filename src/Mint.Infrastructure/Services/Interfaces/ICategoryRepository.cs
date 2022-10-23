using Mint.Domain.Models;

namespace Mint.Infrastructure.Services.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();

    Task<Category> AddCategoryAsync(Category category);

    Task<Category> UpdateCategoryAsync(Category category);

    Task<Category> DeleteCategoryAsync(Category category);
}
