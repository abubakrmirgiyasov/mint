using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
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
        //CategoryViewModel = new CategoryManager().FormingViewModel(category);
    }

    public void OnPost()
    {
        try
        {
            var categoryBindingModel = new CategoryBindingModel();

            if (Request.Query["id"] != "")
            {
                UpdateCategory(categoryBindingModel);
            }
            else
            {
                AddCategory(categoryBindingModel);
            }
        }
        catch (Exception ex)
        {
            ViewData["Errors"] = ex.Message;
            Console.WriteLine(ex.Message);
        }
    }

    private async void AddCategory(CategoryBindingModel categoryBindingModel)
    {
        var category = Request.Form["CategoryName"];
        var uids = Request.Form["BrandId"].ToArray();
        var brands = Request.Form["BrandName"].ToArray();
        var photos = Request.Form.Files;

        categoryBindingModel.Id = Guid.Parse(Request.Query["id"]);
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

        await _category.AddCategory(categoryBindingModel);
    }

    private async void UpdateCategory(CategoryBindingModel categoryBindingModel)
    {
        var category = Request.Form["CategoryName"];
        var uids = Request.Form["BrandId"].ToArray();
        var brands = Request.Form["BrandName"].ToArray();
        var photos = Request.Form.Files;

        categoryBindingModel.Id = Guid.Parse(Request.Query["id"]);
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

}
