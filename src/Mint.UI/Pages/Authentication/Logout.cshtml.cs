using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.UI.Services;

namespace Mint.UI.Pages.Authentication
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Remove("__ID-acces-token");
            //Response.Redirect("/");
        }
    }
}
