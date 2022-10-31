using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Middleware.Services;

namespace Mint.UI.Pages.Authentication;

public class LogoutModel : PageModel
{
    public void OnGet()
    {
        HttpContext.Session.RemoveSession("__ID-acces-token");
        Response.Redirect("/");
    }
}
