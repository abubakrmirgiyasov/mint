using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Services.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var brands = await _context.Categories
                .Include(x => x.Photos)
                .Include(x => x.Brands!)
                .ThenInclude(x => x.Photos)
                .Include(x => x.SubCategories!)
                .ThenInclude(x => x.Photos)
                .ToListAsync();
            return brands;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        try
        {
            var category = await _context.Categories
                .Include(x => x.Photos)
                .Include(x => x.Brands!)
                .ThenInclude(x => x.Photos)
                .Include(x => x.SubCategories!)
                .ThenInclude(x => x.Photos)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                throw new ContentNotFoundException("Категория с таким ID не существует");
            }

            return category;
        }
        catch (ContentNotFoundException ex)
        {
            throw new ContentNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    //public async Task<Brand> GetBrandByIdAsync(Guid id)
    //{
    //    try
    //    {
    //        var brand = await _context.Brands
    //            .Include(x => x.Categories!)
    //            .ThenInclude(x => x.SubCategories)
    //            .FirstOrDefaultAsync(x => x.Id == id);

    //        if (brand == null)
    //        {
    //            throw new ContentNotFoundException("Бренд с таким ID не существует");
    //        }

    //        return brand;
    //    }
    //    catch (ContentNotFoundException ex)
    //    {
    //        throw new ContentNotFoundException(ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message, ex);
    //    }
    //}

    //public async Task<Brand> AddBrandAsync(BrandBindingModel brandBindingModel)
    //{
    //    try
    //    {
    //        var newBrand = new BrandManager().FormingBindingModel(brandBindingModel);

    //        await _context.Brands.AddAsync(newBrand);
    //        await _context.SaveChangesAsync();

    //        return newBrand;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message, ex);
    //    }
    //}

    //public async Task<string> UpdateBrandAsync(BrandBindingModel brand)
    //{
    //    try
    //    {
    //        var updateBrand = await GetBrandByIdAsync(brand.Id);

    //        updateBrand.Name = brand.Name;
    //        updateBrand.Photos = new PhotoManager().FormingBindingModel(brand.Photos);

    //        for (int i = 0; i < brand.Categories.Count; i++)
    //        {
    //            updateBrand.Categories!.ToList()[i].Name = brand.Categories[i].Name;
    //            updateBrand.Categories!.ToList()[i].Photos = new PhotoManager().FormingBindingModel(brand.Photos);
    //        }

    //        _context.Brands.Update(updateBrand);
    //        await _context.SaveChangesAsync();

    //        return "Updated";
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message, ex);
    //    }
    //}

    //public async Task<Brand> DeleteBrandAsync(BrandBindingModel brand)
    //{
    //    return new Brand();
    //}

    //public async Task<List<Category>> GetCategoriesAsync()
    //{
    //    try
    //    {
    //        var categories = await _context.Categories
    //            .ToListAsync();
    //        return categories;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message, ex);
    //    }
    //}

    //public async Task<Category> AddCategoryAsync(CategoryBindingModel categoryBindingModel)
    //{
    //    try
    //    {
    //        //var newCategory = new Brand
    //        //{
    //        //    Id = 
    //        //};

    //        //await _context.Brands.AddAsync(newCategory);
    //        //await _context.SaveChangesAsync();
    //        return new Category();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message, ex);
    //    }
    //}

    //public Task<Category> UpdateCategoryAsync(CategoryBindingModel category)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<Category> DeleteCategoryAsync(CategoryBindingModel category)
    //{
    //    throw new NotImplementedException();
    //}
}
