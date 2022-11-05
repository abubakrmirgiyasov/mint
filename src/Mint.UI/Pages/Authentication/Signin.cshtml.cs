using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.BindingModels;
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

        public async Task OnPost(UserBindingModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var token = await _authentication.SignIn(user);

                    //if (bool.Parse(Request.Query["RememberMe"]) == true)
                    //{
                    //    Params.ExpireTokenTime = 7;
                    //}

                    HttpContext.Session.SetString("__ID-acces-token", token);

                    User.AddIdentity(HttpContext.GetClaimsIdentity());

                    Response.Redirect("/");
                }
                else
                {
                    ViewData["Message"] = "Неправильный логин/пароль";
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
