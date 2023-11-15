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
    public async Task<IActionResult> CreateAuthor(AuthorModel authorModel)
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
}     