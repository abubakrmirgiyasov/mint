using Microsoft.EntityFrameworkCore;
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
               .ToListAsync();
            return categories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<Category> AddCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> DeleteCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }
}
