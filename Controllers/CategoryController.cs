using Ecc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecc.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    [HttpPost("createcategory")]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryModel categoryModel)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(categoryModel.Name))
            {
                return BadRequest("O nome da categoria precisa ser peenchido.");
            }

            var category = await _categoryRepository.CreateCategory(categoryModel);
            if (category == null)
            {
                return BadRequest("A categoria não pode ser nula");
            }

            return Ok(category);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("updatecategory/{categoryId}")]
    public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody] CategoryModel categoryModel)
    {
        try
        {
            var updatecategory = await _categoryRepository.UpdateCategory(categoryId, categoryModel);
           
            return Ok(updatecategory);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("getcategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        try
        {
            List<CategoryModel> categories = await _categoryRepository.GetCategories();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("deletecategory")]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        try 
        {
            var category = await _categoryRepository.DeleteCategory(categoryId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok("Category deleted");
    }

    [HttpGet("getcategorybyid/{categoryId}")]
    public async Task<IActionResult> GetCategoryById(Guid categoryId)
    {
        try
        {
            var categoryById = await _categoryRepository.GetCategoryById(categoryId);
            return Ok(categoryById);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}