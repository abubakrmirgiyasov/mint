using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Extensions;
using Mint.Domain.Models;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = Constants.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class HomeController : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        return Ok(new User()
        {
            FirstName = "Test",
            SecondName = "User",
            CreatedDate = new DateTime(2001, 12, 05),
            Email = "abubakrmirgiyasov@gmail.com",
            Ip = "127.0.0.1:1011",
        });
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Post()
    {
        return Ok();
    }
}
