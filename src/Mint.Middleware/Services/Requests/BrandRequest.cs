using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class BrandRequest : IBrandRequest
{
    public async Task<List<Brand>> GetBrandsAsync()
    {
        var baseRequestService = new RequestService<List<Brand>>(false);
        return await baseRequestService.GetRequestAsync("api/brand/getbrands");
    }

    public async Task<Brand> GetBrandByIdAsync(Guid id)
    {
        var baseRequestService = new RequestService<Brand>(true);
        return await baseRequestService.GetRequestAsync("api/brand/getbrandbyid/" + id);
    }

    public async Task<BrandBindingModel> AddBrandAsync(BrandBindingModel brand)
    {
        var baseRequestService = new RequestService<BrandBindingModel>(true);
        var content = new JsonContent<BrandBindingModel>().GetContent(brand);
        return await baseRequestService.PostRequestAsync(content, "api/brand/addbrand");
    }

    public async Task<BrandBindingModel> UpdateBrandAsync(BrandBindingModel brand)
    {
        var baseRequestService = new RequestService<BrandBindingModel>(true);
        var content = new JsonContent<BrandBindingModel>().GetContent(brand);
        return await baseRequestService.UpdateRequestAsync(content, "api/brand/updatebrand");
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var baseRequestService = new RequestService<List<Category>>(false);
        return await baseRequestService.GetRequestAsync("api/brand/getcategories");
    }
}
