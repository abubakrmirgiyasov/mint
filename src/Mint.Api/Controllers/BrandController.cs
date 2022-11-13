using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BrandController : ControllerBase
{
	private readonly IBrandRepository _brand;

	public BrandController(IBrandRepository category)
	{
		_brand = category;
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetBrands()
	{
		try
		{
			var brands = await _brand.GetBrandsAsync();
			return Ok(brands);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBrandById(Guid id)
	{
		try
		{
            var brand = await _brand.GetBrandByIdAsync(id);
            return Ok(brand);
        }
        catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	[HttpPost]
	public IActionResult AddBrand(BrandBindingModel brand)
	{
		try
		{
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	public async Task<IActionResult> UpdateBrand(BrandBindingModel brand)
	{
		try
		{
            var updatedBrand = await _brand.UpdateBrandAsync(brand);
            return Ok(updatedBrand);
        }
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	public IActionResult DeleteBrand(BrandBindingModel brand)
	{
		try
		{
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetCategories()
	{
		try
		{
			var categories = await _brand.GetCategoriesAsync();
			return Ok(categories);
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
            return BadRequest(ex.Message);
        }
	}
    
	[HttpPut]
	public async Task<IActionResult> UpdateCategory(CategoryBindingModel category)
	{
		try
		{
			var newCategory = await _brand.UpdateCategoryAsync(category);
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
            return BadRequest(ex.Message);
        }
	}
}
