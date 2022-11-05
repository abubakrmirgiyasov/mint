using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Extensions;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        try
        {
            var category = await _category.GetCategoryByIdAsync(id);
            return Ok(category);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

	[HttpPost]
	public IActionResult AddCategory(CategoryBindingModel category)
	{
		try
		{
			return Ok(category);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
    
	[HttpPut]
	public async Task<IActionResult> UpdateCategory(CategoryBindingModel category)
	{
		try
		{
			var newCategory = await _category.UpdateCategoryAsync(category);
			return Ok(newCategory);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteCategory(Guid id)
	{
		try
		{
			return Ok();
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
