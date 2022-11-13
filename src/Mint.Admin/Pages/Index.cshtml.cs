using Microsoft.AspNetCore.Mvc.RazorPages;
using Mint.Admin.Services;
using Mint.Domain.BindingModels;
using Mint.Middleware.Extensions;
using Mint.Middleware.Services;
using Mint.Middleware.Services.Interfaces;

namespace Mint.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAdminRequestService _admin;

        public IndexModel(ILogger<IndexModel> logger, IAdminRequestService admin)
        {
            _logger = logger;
            _admin = admin;
        }

        public void OnGet()
        {
            //if (HttpContext.IsAuthenticated())
            //{
            //    Response.Redirect("/dashboard/");
            //}
        }

        public async Task OnPost(AdminBindingModel admin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var token = await _admin.Login(admin);

                    HttpContext.Session.SetSession(Params.SESSION_TOKEN_NAME, token);

                    Response.Redirect("/dashboard/");
                }
                else
                {
                    ViewData["Error"] = "Заполните все поля";
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}