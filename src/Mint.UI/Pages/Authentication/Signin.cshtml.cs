using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.Extensions;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;
using Mint.UI.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            if (User.Identity!.IsAuthenticated)
            {
                Response.Redirect("/test/users");
            }
        }

        public async Task OnPost(UserViewModel user)
        {
            try
            {
                var token = await _authentication.SignIn(user);

                HttpContext.Session.SetString("__ID-acces-token", token);

                Response.Redirect("/test/users");
            }
            catch (Exception ex)
            {
                ViewData["Errors"] = ex.Message;
            }
        }
    }
}
