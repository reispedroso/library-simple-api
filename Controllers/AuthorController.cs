using Ecc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecc.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpPost("createauthor")]
    public async Task<ActionResult<AuthorModel>> CreateAuthor(AuthorModel authorModel)
    {
        if(!ModelState.IsValid || authorModel == null)
        {
            return BadRequest("invalid author model");
        }

        var author = await _authorRepository.CreateAuthor(authorModel);
        if(author == null)
        {
            return Conflict("The author cannot be null");
        }
        return Ok(author);
    }

    [HttpGet("getallauthors")]
    public async Task<ActionResult<IEnumerable<AuthorModel>>> GetAllUsers()
    {
        try
        {
            var authors = await _authorRepository.GetAllAuthors();
            return authors;
        }
        catch(Exception ex)
        {
            return BadRequest($"We catch the following error: {ex.Message}");
        }
    }

    [HttpGet("getauthorbyid/{authorId}")]
    public async Task<ActionResult<AuthorModel>> GetAuthorById(Guid authorId)
    {
         try
        {
            var author = await _authorRepository.GetAuthorById(authorId);
            return author;
        }
        catch(Exception ex)
        {
            return BadRequest($"We catch the following error: {ex.Message}");
        }
    }
    [HttpPut("updateauthor/{authorId}")]
    public async Task<ActionResult<AuthorModel>> UpdateAuthor(Guid authorId, AuthorModel authorModel)
    {
        try
        {
            var updatedAuthor = await _authorRepository.UpdateAuthor(authorId, authorModel);
            return updatedAuthor;
        }
        catch(Exception ex)
        {
            return BadRequest($"We catch the following error: {ex.Message}");
        }
    }
    
    [HttpDelete("deleteauthor/{authorId}")]
    public async Task<ActionResult> DeleteAuthor (Guid authorId)
    {
          try
        {
            var success = await _authorRepository.DeleteAuthor(authorId);

            if (!success)
            {
                return NotFound($"Author with this Id:{authorId} was not found");
            }

            return Ok($"Author {authorId} deleted. ");

        }
        catch (Exception ex)
        {
            return BadRequest($"We catch this erros: {ex.Message}");
        }
    }
    
}     