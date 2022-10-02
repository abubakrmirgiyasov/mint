using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _user;

    public AuthenticationController(IUserRepository user)
    {
        _user = user;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var users = await _user.GetUsersAync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        try
        {
            var user = await _user.GetUserByIdAync(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        try
        {
            var user = await _user.GetUserByEmailAync(email);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{phone}")]
    public async Task<IActionResult> GetUserByPhone(long phone)
    {
        try
        {
            var user = await _user.GetUserByPhoneAync(phone);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp(User user)
    {
        try
        {
            var newUser = await _user.AddUserWithPhoneAync(user);
            return Ok(newUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, "Admin"),
        };

        var token = new JwtSecurityToken(
            issuer: Constants.ISSUER,
            audience: Constants.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1), // test
            signingCredentials: new SigningCredentials(
                Constants.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }
}
