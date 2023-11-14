namespace Ecc.Repositories.Interfaces;

public interface IBookRepository 
{
    Task<BookModel> CreateNewBook(BookModel bookModel);
    Task<BookModel> UpdateBook(Guid bookId, BookModel bookModel);
    Task<List<BookModel>> GetAllBooks();
    Task<bool> DeleteBook(Guid bookId);
    Task<BookModel> GetBookById(Guid bookId);
}