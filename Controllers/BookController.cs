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
    public async Task<ActionResult<BookModel>> CreateNewBook([FromBody] BookModel bookModel)
    {
        if (!ModelState.IsValid || bookModel == null)
        {
            return BadRequest("Invalid book model.");
        }

        var book = await _bookRepository.CreateNewBook(bookModel);
        if (book == null)
        {
            return Conflict("The book model cannot be null");
        }

        return Ok(book);
    }
// ---------
    [HttpGet("getallbooks")]
    public async Task<ActionResult<IEnumerable<BookModel>>> GetAllUsers()
    {
        try
        {
            var books = await _bookRepository.GetAllBooks();
            if (books == null)
            {
                return NotFound($"No book was found");
            }
            return Ok(books);

        }
        catch (Exception ex)
        {
            return BadRequest($"We catch this erros: {ex.Message}");
        }

    }
// ---------
    [HttpGet("getbookbyid/{bookId}")]
    public async Task<ActionResult<BookModel>> GetBookById(Guid bookId)
    {
        try
        {
            var book = await _bookRepository.GetBookById(bookId);
            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest($"We catch this erros: {ex.Message}");
        }
    }
// ---------
    [HttpPut("updatebook/{bookId}")]
    public async Task<ActionResult<BookModel>> UpdateBook(Guid bookId, [FromBody] BookModel bookModel)
    {
        try
        {
            var book = await _bookRepository.UpdateBook(bookId, bookModel);

            if (book == null)
            {
                return BadRequest("Invalid book model");
            }

            return Ok(book);
        }
        catch (Exception ex)
        {
            return BadRequest("do something right man");
        }
    }
// ---------
    [HttpDelete("deletebook/{bookId}")]
    public async Task<ActionResult> DeleteUser(Guid bookId)
    {
        try
        {
            var success = await _bookRepository.DeleteBook(bookId);

            if (!success)
            {
                return NotFound($"Book with this Id:{bookId} was not found");
            }

            return Ok($"Book {bookId} deleted. ");

        }
        catch (Exception ex)
        {
            return BadRequest($"We catch this erros: {ex.Message}");
        }
    }


}