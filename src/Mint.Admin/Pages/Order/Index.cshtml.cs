using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mint.Admin.Pages.Order
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Order"] = "active";
        }
    }
}
