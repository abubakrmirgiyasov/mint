using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Admin.Services;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages.Brand
{
    public class IndexModel : PageModel
    {
        public List<BrandViewModel> Brands { get; set; } = null!;

        private readonly IBrandRequest _brand;

        public IndexModel(IBrandRequest category)
        {
            _brand = category;
        }

        public async Task OnGet()
        {
            if (HttpContext.IsAuthenticated())
            {
                ViewData["Category"] = "active";
                Brands = new BrandManager().FormingViewModels(await _brand.GetBrandsAsync());
            }
        }
    }
}
