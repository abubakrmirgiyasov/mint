using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Middleware.Services.Interfaces;

public interface ICategoryRequest
{
    Task<List<CategoryViewModel>> GetCategories();
}
