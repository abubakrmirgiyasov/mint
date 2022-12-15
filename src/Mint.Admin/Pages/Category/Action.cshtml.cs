using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Admin.Services;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages.Category
{
    public class ActionModel : PageModel
    {
        public CategoryViewModel? Category { get; set; }

        private readonly ICategoryRequest _category;

        public ActionModel(ICategoryRequest category)
        {
            _category = category;
        }

        public async Task OnGet()
        {
            try
            {
                if (new AdminLoginService(this).IsAuthenticated())
                {
                    var id = HttpContext.Request.Query["id"];

                    if (Guid.TryParse(id, out Guid parsedId))
                    {
                        Category = new CategoryManager().FormingViewModel(await _category.GetCategoryByIdAsync(parsedId));
                    }
                }
                else
                {
                    Response.Redirect("/");
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
        }

        public async Task OnPost()
        {
            try
            {
                if (new AdminLoginService(this).IsAuthenticated())
                {
                    var id = HttpContext.Request.Query["id"];
                    var brandId = HttpContext.Request.Form["BrandId"];
                    //var 

                    if (Guid.TryParse(id, out Guid parsedId))
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    Response.Redirect("/");
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
        }
    }
}
