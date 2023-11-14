
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

    public async Task<BookModel> UpdateBook(Guid bookId, BookModel bookModel)
    {
        var book = await _context.Books.FirstOrDefaultAsync(i => i.BookId == bookId);
        if(book != null)
        {
            book.Name = bookModel.Name;
        }

         _context.Books.Update(book);
         await _context.SaveChangesAsync();
         return book;
    }
}
