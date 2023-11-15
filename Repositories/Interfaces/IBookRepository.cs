namespace Ecc.Repositories.Interfaces;

public interface IBookRepository 
{
    Task<BookModel> CreateNewBook(BookModel bookModel);
    Task<List<BookModel>> GetAllBooks();
    Task<BookModel> GetBookById(Guid bookId);
    Task<BookModel> UpdateBook(Guid bookId, BookModel bookModel);
    Task<bool> DeleteBook(Guid bookId);
}