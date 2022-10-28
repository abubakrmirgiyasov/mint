using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mint.Admin.Pages.Prouct
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["Product"] = "active";
        }
    }
}
