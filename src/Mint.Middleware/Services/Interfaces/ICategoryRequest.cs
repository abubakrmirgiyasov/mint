using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Middleware.Services.Interfaces;

public interface ICategoryRequest
{
    Task<List<Category>> GetCategoriesAsync();

    Task<Category> GetCategoryByIdAsync(Guid id);
}
