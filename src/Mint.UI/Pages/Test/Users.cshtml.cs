using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Middleware.Services.Interfaces;
using Mint.UI.Services;

namespace Mint.UI.Pages.Test;

public class UsersModel : PageModel
{
    public bool IsAuthenticated
    {
        get
        {
            try
            {
                var role = ServiceCollectionsExtension.GetRole<string>(HttpContext.Session, "__ID-acces-token");
                return role != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }

    private readonly IAuthenticationRequest _authentication;

    public UsersModel(IAuthenticationRequest authentication)
    {
        _authentication = authentication;
    }

    public async Task OnGet()
    {
        if (IsAuthenticated)
        {
            ViewData["List"] = await _authentication.GetUsers();
        }
        else
        {
            Response.Redirect("/authentication/signin");
        }
    }
}
