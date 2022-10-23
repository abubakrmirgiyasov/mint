using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Api.Controllers;

public class CategoryController : ControllerBase
{
	private readonly ICategoryRepository _category;

	public CategoryController(ICategoryRepository category)
	{
		_category = category;
	}

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
