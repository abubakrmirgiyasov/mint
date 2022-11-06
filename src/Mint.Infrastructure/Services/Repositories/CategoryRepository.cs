using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
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
            var categories = await _context.Categories
                //.Include(x => x.Brands)
                .ToListAsync();
            return categories;
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
                //.Include(x => x.Brands)
                .FirstOrDefaultAsync(x => x.Id == id);
            return category!;
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
            var newCategory = new Category(); // CategoryManager().FormingBindingModel(category);

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<Category> UpdateCategoryAsync(CategoryBindingModel category)
    {
        var newCategory = await GetCategoryByIdAsync(category.Id);

        newCategory.Name = category.Name;
        //newCategory.Brands = new BrandManager().FormingBindingModels(category.Brands, category.Id);

        _context.Categories.Update(newCategory);
        await _context.SaveChangesAsync();
       
        return newCategory;
    }

    public Task<Category> DeleteCategoryAsync(CategoryBindingModel category)
    {
        throw new NotImplementedException();
    }
}
