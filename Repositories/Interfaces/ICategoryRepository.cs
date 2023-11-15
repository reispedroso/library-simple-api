namespace Ecc.Repositories.Interfaces;

public interface ICategoryRepository {
    Task<CategoryModel> CreateCategory(CategoryModel categoryModel);
    Task<List<CategoryModel>> GetCategories();
    Task<CategoryModel> UpdateCategory(Guid categoryId, CategoryModel categoryModel);
    Task<bool> DeleteCategory(Guid categoryId);
    Task<CategoryModel> GetCategoryById(Guid categoryId);
}