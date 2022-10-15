using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _user;

    public AuthenticationController(IUserRepository user)
    {
        _user = user;
    }

    [HttpGet]
    [Authorize(Roles = Constants.ADMIN)]
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
    [Authorize(Roles = Constants.ADMIN)]
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
    [Authorize(Roles = Constants.ADMIN)]
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

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(UserViewModel user)
    {
        try
        {
            var token = await _user.GetSigninUser(user.Email!, user.Password);
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        catch (UserBlockedException ex)
        {
            return Forbid($"{ex.Message}. Ссылка для помощи {ex.HelpLink}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
