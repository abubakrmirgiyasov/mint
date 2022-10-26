using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages.Category
{
    public class IndexModel : PageModel
    {
        public List<CategoryViewModel> Categories { get; set; } = null!;

        private readonly ICategoryRequest _category;

        public IndexModel(ICategoryRequest category)
        {
            _category = category;
        }

        public async Task OnGet()
        {
            Categories = await _category.GetCategories();
        }
    }
}
