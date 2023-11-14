using Ecc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecc;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    [HttpPost("createbook")]
    public async Task<IActionResult> CreateNewBook([FromBody] BookModel bookModel)
    {
        if (!ModelState.IsValid || bookModel == null)
        {
            return BadRequest("Invalid book model.");
        }

        var book = await _bookRepository.CreateNewBook(bookModel);
        if(book == null)
        {
            return Conflict("The book model cannot be null");
        }

        return Ok(book);
    }

    [HttpPut("updatebook/{bookId}")]
    public async Task<IActionResult> UpdateBook(Guid bookId, [FromBody] BookModel bookModel)
    {
        
    }
}