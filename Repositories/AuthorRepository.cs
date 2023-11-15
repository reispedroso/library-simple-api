using Ecc.Context;
using Ecc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecc.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;
    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<AuthorModel> CreateAuthor(AuthorModel authorModel)
    {
        var author = new AuthorModel
        {
            Name = authorModel.Name
        };

        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();

        return author;
    }
    public async Task<List<AuthorModel>> GetAllAuthors()
    {
        List<AuthorModel> author = await _context.Authors.ToListAsync();
        return author;
    }
    public async Task<AuthorModel> GetAuthorById(Guid authorId)
    {
        var author = await _context.Authors.FirstAsync(a => a.AuthorId == authorId);
        return author;
    }
    public async Task<AuthorModel> UpdateAuthor(Guid authorId, AuthorModel authorModel)
    {
        var updatedAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
        if (updatedAuthor != null && updatedAuthor.Name != authorModel.Name)
        {
            updatedAuthor.Name = authorModel.Name;
        }
        else
        {
            throw new BadHttpRequestException("that ain't gonna work");
        }
        _context.Authors.Update(updatedAuthor);
        await _context.SaveChangesAsync();
        return updatedAuthor;

    }
    public async Task<bool> DeleteAuthor(Guid authorId)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
        _context.Remove(author);
        await _context.SaveChangesAsync();
        return true;
    }

}