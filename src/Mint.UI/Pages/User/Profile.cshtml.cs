using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Middleware.Services.Interfaces;
using Mint.UI.Services;

namespace Mint.UI.Pages.User
{
    public class ProfileModel : PageModel
    {
        internal UserViewModel UserViewModel { get; set; } = null!;

        private readonly IUserRequest _userRequest;

        public ProfileModel(IUserRequest userRequest)
        {
            _userRequest = userRequest;
        }

        public async Task OnGet()
        {
            if (!HttpContext.IsAuthenticated())
            {
                Response.Redirect("/authentication/signin");
            }

            var user = await _userRequest.GetUserById(Guid.Parse(Request.Query["user"]));
            UserViewModel = new UserManager().FormingViewModel(user);
        }
    }
}
