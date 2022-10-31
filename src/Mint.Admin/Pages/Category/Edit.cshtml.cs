using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages.Category;

public class EditModel : PageModel
{
    internal CategoryViewModel CategoryViewModel { get; set; } = null!;

    private readonly ICategoryRequest _category;

    public EditModel(ICategoryRequest category)
    {
        _category = category;
    }

    public async Task OnGet()
    {
        var id = Request.Query["id"];
        if (string.IsNullOrEmpty(id))
        {
            return;
        }
        var category = await _category.GetCategoryById(Guid.Parse(id));
        CategoryViewModel = new CategoryManager().FormingViewModel(category);
    }

    public async Task OnPost()
    {
        try
        {
            var categoryBindingModel = new CategoryBindingModel();
            var category = Request.Form["CategoryName"];
            var uids = Request.Form["BrandId"].ToArray();
            var brands = Request.Form["BrandName"].ToArray();
            var photos = Request.Form.Files;

            categoryBindingModel.Name = category;
            categoryBindingModel.Brands = new List<BrandBindingModel>();

            for (int i = 0; i < brands.Length; i++)
            {
                if (i < uids.Length)
                {
                    categoryBindingModel.Brands.Add(new BrandBindingModel()
                    {
                        Id = Guid.Parse(uids[i]),
                        Name = brands[i],
                        Photos = await new PhotoManager().AddPhotoAsync(photos)
                    });
                }
                else
                {
                    categoryBindingModel.Brands.Add(new BrandBindingModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = brands[i],
                        Photos = await new PhotoManager().AddPhotoAsync(photos)
                    });
                }
            }

            await _category.UpdateCategory(categoryBindingModel);
        }
        catch (Exception ex)
        {
            ViewData["Errors"] = ex.Message;
            Console.WriteLine(ex.Message);
        }
    }
}
