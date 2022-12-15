using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.UI.Pages;

public class IndexModel : PageModel
{
    public List<CategoryViewModel>? Categories { get; set; }

    private readonly ICategoryRequest _category;

    public IndexModel(ICategoryRequest category)
    {
        _category = category;
    }

    public async Task OnGet()
    {
        Categories = new CategoryManager().FormingViewModels(await _category.GetCategoriesAsync());
    }
}
