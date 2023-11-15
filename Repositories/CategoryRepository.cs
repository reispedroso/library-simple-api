using Ecc.Context;
using Ecc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecc.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<CategoryModel> CreateCategory(CategoryModel categoryModel)
    {
        var category = new CategoryModel
        {
            Name = categoryModel.Name
        };

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }
    public async Task<List<CategoryModel>> GetAllCategories()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }
    public async Task<CategoryModel> GetCategoryById(Guid categoryId)
    {
        var categoryById = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId); 
        return categoryById;
    }
     public async Task<CategoryModel> UpdateCategory(Guid categoryId, CategoryModel categoryModel)
    {
        var updatedCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);

        if (updatedCategory != null && updatedCategory.Name != categoryModel.Name)
        {
            updatedCategory.Name = categoryModel.Name;
        }
        else
        {
            throw new BadHttpRequestException("Ou o id eh nulo ou o nome eh igual cpx kkk");
        }
        _context.Categories.Update(updatedCategory);
        await _context.SaveChangesAsync();
        return updatedCategory;
    }
    public async Task<bool> DeleteCategory(Guid categoryId)
    {
        var category = _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        _context.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}