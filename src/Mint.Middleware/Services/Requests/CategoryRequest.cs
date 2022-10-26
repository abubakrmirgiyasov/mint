using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class CategoryRequest : ICategoryRequest
{
    public async Task<List<CategoryViewModel>> GetCategories()
    {
        var baseRequestService = new RequestService<List<CategoryViewModel>>(false);
        return await baseRequestService.GetRequestAsync("api/category/getcategories");
    }
}
