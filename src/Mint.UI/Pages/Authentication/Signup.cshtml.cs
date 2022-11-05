using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.BindingModels;
using Mint.Domain.Extensions;
using Mint.Domain.FormingModels;
using Mint.Middleware.Services.Interfaces;
using Mint.UI.Services;

namespace Mint.UI.Pages.Authentication
{
    public class SingupModel : PageModel
    {
        private readonly IAuthenticationRequest _request;

        public IFormFileCollection? Files { get; set; }

        public SingupModel(IAuthenticationRequest request)
        {
            _request = request;
        }

        public void OnGet()
        {
            if (HttpContext.IsAuthenticated())
            {
                Response.Redirect("/");
            }
        }

        public async void OnPost(UserBindingModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientAddress = Request.HttpContext.Connection.RemoteIpAddress;

                    user.Password = Encrypt.EncodePassword(user.Password);
                    user.ConfirmPassword = Encrypt.EncodePassword(user.ConfirmPassword);
                    user.Photo =  new PhotoManager().FormingSinglePhoto(await new PhotoManager().AddPhotoAsync(Files));
                    user.Ip = clientAddress!.ToString();

                    if (user.Password == user.ConfirmPassword)
                    {
                        await _request.SignUp(user);

                        Response.Redirect("/authentication/signin");
                    }
                }
                else
                {
                    ViewData["Error"] = "Заполните все поля корректно!";
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
