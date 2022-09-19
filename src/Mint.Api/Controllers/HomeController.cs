using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Extensions;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Api.Controllers;

[Authorize(Roles = Constants.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IUserRepository _user;

    public HomeController(IUserRepository user)
    {
        _user = user;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> SignUp()
    {
        return Ok();
    }
}
