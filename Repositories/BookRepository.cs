
using System.Security.Cryptography.X509Certificates;
using System.Web.Http.Results;
using Ecc.Context;
using Ecc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecc.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<BookModel> CreateNewBook(BookModel bookModel)
    {
        var book = new BookModel
        {
            Name = bookModel.Name,
            PublishDate = DateTimeUtils.ReplaceMinValueWithFutureDate(bookModel.PublishDate),
            CategoryId = bookModel.CategoryId,
            AuthorId = bookModel.AuthorId
        };

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }
    public async Task<List<BookModel>> GetAllBooks()
    {
        var books = await _context.Books.ToListAsync();
        foreach(var book in books)
        {
             book.PublishDate = book.PublishDate.AddHours(-3);
        }
        return books;
    }
    public async Task<BookModel> GetBookById(Guid bookId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
        if(book != null)
        {
            book.PublishDate = book.PublishDate.AddHours(-3);
            return book;
        }
        return book;
    }
      public async Task<BookModel> UpdateBook(Guid bookId, BookModel bookModel)
    {
        var book = await _context.Books.FirstOrDefaultAsync(i => i.BookId == bookId);
        if (book != null)
        {
            book.Name = bookModel.Name;
        }

        _context.Books.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }
     public async Task<bool> DeleteBook(Guid bookId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);

        if (book == null)
        {
            return false;
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }
}
