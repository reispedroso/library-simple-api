namespace Ecc.Repositories.Interfaces;

public interface ICategoryRepository {
    Task<CategoryModel> CreateCategory(CategoryModel categoryModel);
    Task<CategoryModel> GetCategoryById(Guid categoryId);
    Task<List<CategoryModel>> GetAllCategories();
    Task<CategoryModel> UpdateCategory(Guid categoryId, CategoryModel categoryModel);
    Task<bool> DeleteCategory(Guid categoryId);
}