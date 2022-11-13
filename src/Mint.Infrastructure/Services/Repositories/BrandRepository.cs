using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Services.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _context;

    public BrandRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Brand>> GetBrandsAsync()
    {
        try
        {
            var brands = await _context.Brands
                .Include(x => x.Categories!)
                .ThenInclude(x => x.SubCategories)
                .ToListAsync();
            return brands;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _context.Categories
                .ToListAsync();
            return categories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Brand> GetBrandByIdAsync(Guid id)
    {
        try
        {
            var brand = await _context.Brands
                .Include(x => x.Categories!)
                .ThenInclude(x => x.SubCategories)
                .FirstOrDefaultAsync(x => x.Id == id);
            return brand!;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Category> AddCategoryAsync(CategoryBindingModel category)
    {
        try
        {
            var newCategory = new Category();

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<string> UpdateBrandAsync(BrandBindingModel brand)
    {
        try
        {
            var updateBrand = await GetBrandByIdAsync(brand.Id);

            updateBrand.Name = brand.Name;
            updateBrand.Photos = new PhotoManager().FormingBindingModel(brand.Photos);

            for (int i = 0; i < brand.Categories.Count; i++)
            {
                updateBrand.Categories!.ToList()[i].Name = brand.Categories[i].Name;
                updateBrand.Categories!.ToList()[i].Photos = new PhotoManager().FormingBindingModel(brand.Photos);

                for (int j = 0; j < brand.Categories[i].SubCategories.Count; j++)
                {
                    updateBrand.Categories!.ToList()[i].SubCategories!.ToList()[j].Name = brand.Categories[i].SubCategories[j].Name;
                    updateBrand.Categories!.ToList()[i].SubCategories!.ToList()[j].Photos = new PhotoManager().FormingBindingModel(brand.Categories[i].SubCategories[j].Photos);
                }
            }

            _context.Brands.Update(updateBrand);
            await _context.SaveChangesAsync();

            return "Updated";
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<Category> DeleteCategoryAsync(CategoryBindingModel category)
    {
        throw new NotImplementedException();
    }

    public Task<Brand> UpdateCategoryAsync(CategoryBindingModel category)
    {
        throw new NotImplementedException();
    }
}
