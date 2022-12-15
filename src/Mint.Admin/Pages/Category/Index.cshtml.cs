using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Admin.Services;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages.Category
{
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
            if (new AdminLoginService(this).IsAuthenticated())
            {
                ViewData["Category"] = "active";

                Categories = new CategoryManager().FormingViewModels(await _category.GetCategoriesAsync());
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}
