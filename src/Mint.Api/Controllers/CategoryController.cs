using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CategoryController : ControllerBase
{
	private readonly ICategoryRepository _category;

	public CategoryController(ICategoryRepository category)
	{
		_category = category;
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetCategories()
	{
		try
		{
			var categories = await _category.GetCategoriesAsync();
			return Ok(categories);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
