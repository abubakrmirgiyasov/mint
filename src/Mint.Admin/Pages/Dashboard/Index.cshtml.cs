using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Admin.Services;

namespace Mint.Admin.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if (HttpContext.IsAuthenticated())
            {
                ViewData["Home"] = "active";
            }
            else
            {
                Response.Redirect("/");
            }
        }
    }
}
