using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Middleware.Services.Interfaces;

public interface ICategoryRequest
{
    Task<List<Category>> GetCategories();

    Task<Category> GetCategoryById(Guid id);

    Task<CategoryBindingModel> AddCategory(CategoryBindingModel category);

    Task<CategoryBindingModel> UpdateCategory(CategoryBindingModel category);
}
