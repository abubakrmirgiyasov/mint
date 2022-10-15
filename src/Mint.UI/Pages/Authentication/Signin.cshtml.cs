using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.ViewModels;
using Mint.Middleware.Extensions;
using Mint.Middleware.Services.Interfaces;
using Mint.UI.Services;

namespace Mint.UI.Pages.Authentication
{
    public class SigninModel : PageModel
    {
        private readonly IAuthenticationRequest _authentication;

        public SigninModel(IAuthenticationRequest authentication)
        {
            _authentication = authentication;
        }

        public void OnGet()
        {
            if (HttpContext.IsAuthenticated())
            {
                Response.Redirect("/");
            }
        }

        public async Task OnPost(UserViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var token = await _authentication.SignIn(user);

                    if (user.RememberMe)
                    {
                        Params.ExpireTokenTime = 7;
                    }

                    HttpContext.Session.SetString("__ID-acces-token", token);

                    User.AddIdentity(HttpContext.GetClaimsIdentity());

                    Response.Redirect("/");
                }
                else
                {
                    ViewData["Message"] = "������������ �����/������";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ViewData["Errors"] = ex.Message;
            }
        }
    }
}
