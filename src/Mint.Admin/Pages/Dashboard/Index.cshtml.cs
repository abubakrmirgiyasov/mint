using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mint.Admin.Pages.Dashboard
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Home"] = "active";
        }
    }
}
