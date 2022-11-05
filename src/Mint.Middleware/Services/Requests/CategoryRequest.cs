﻿using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Middleware.Services.Requests;

public class CategoryRequest : ICategoryRequest
{
    public async Task<List<Category>> GetCategories()
    {
        var baseRequestService = new RequestService<List<Category>>(false);
        return await baseRequestService.GetRequestAsync("api/category/getcategories");
    }

    public async Task<Category> GetCategoryById(Guid id)
    {
        var baseRequestService = new RequestService<Category>(false);
        return await baseRequestService.GetRequestAsync("api/category/getcategorybyid/" + id);
    }

    public async Task<CategoryBindingModel> AddCategory(CategoryBindingModel category)
    {
        var baseRequestService = new RequestService<CategoryBindingModel>(true);
        var content = new JsonContent<CategoryBindingModel>().GetContent(category);
        return await baseRequestService.PostRequestAsync(content, "api/category/addcategory");
    }
    
    public async Task<CategoryBindingModel> UpdateCategory(CategoryBindingModel category)
    {
        var baseRequestService = new RequestService<CategoryBindingModel>(true);
        var content = new JsonContent<CategoryBindingModel>().GetContent(category);
        return await baseRequestService.PostRequestAsync(content, "api/category/updatecategory");
    }
}
