using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AdminController : ControllerBase
{
    private readonly IAdminRepository _admin;

    public AdminController(IAdminRepository admin)
    {
        _admin = admin;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(AdminBindingModel admin)
    {
		try
		{
            var token = await _admin.Login(admin.Email!, admin.Password!);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        catch (Exception ex)
		{
            return BadRequest(ex.Message);
		}
    }
}
