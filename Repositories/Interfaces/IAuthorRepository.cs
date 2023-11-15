namespace Ecc.Repositories.Interfaces;

public interface IAuthorRepository 
{
    Task<AuthorModel> CreateAuthor(AuthorModel authorModel);
    Task<List<AuthorModel>> GetAllAuthors();
    Task<AuthorModel> GetAuthorById(Guid authorId);
    Task<AuthorModel> UpdateAuthor(Guid authorId, AuthorModel authorModel);
    Task<bool> DeleteAuthor(Guid authorId);
}