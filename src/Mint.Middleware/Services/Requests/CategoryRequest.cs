using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class CategoryRequest : ICategoryRequest
{
    public async Task<List<Category>> GetCategoriesAsync()
    {
        var baseRequestService = new RequestService<List<Category>>(false);
        return await baseRequestService.GetRequestAsync("api/category/getcategories");
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        var baseRequestService = new RequestService<Category>(true);
        return await baseRequestService.GetRequestAsync("api/category/getcategorybyid/" + id);
    }
}
