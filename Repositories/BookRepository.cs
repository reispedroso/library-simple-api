
using System.Security.Cryptography.X509Certificates;
using Ecc.Context;
using Ecc.Repositories.Interfaces;

namespace Ecc.Repositories;

public class BookRepository : IRepository<BookModel> 
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BookModel> Create(BookModel book)
     {
        var newBook = new BookModel
        {
            Name = book.Name,
            PublishDate = DateTimeUtils.ReplaceMinValueWithFutureDate(book.PublishDate),
            CategoryId = book.CategoryId,
            AuthorId = book.AuthorId
        };

        await _context.Books.AddAsync(newBook);
        await _context.SaveChangesAsync();
        return newBook;
    }
    public Task Delete(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookModel>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<BookModel> GetById(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<BookModel> Update(Guid guid, BookModel entity)
    {
        throw new NotImplementedException();
    }
}
