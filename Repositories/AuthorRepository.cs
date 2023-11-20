using Ecc.Context;
using Ecc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecc.Repositories;

public class AuthorRepository : IRepository<AuthorModel>
{
    private readonly AppDbContext _context;
    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AuthorModel> Create(AuthorModel author)
    {
        if (author == null)
        {
            throw new Exception("My ng the author cannot be null...");
        }
        var newAuthor = new AuthorModel 
        {
            Name = author.Name
        };

        await _context.Authors.AddAsync(newAuthor);
        await _context.SaveChangesAsync();
        return newAuthor;
    }
  
    public async Task<IEnumerable<AuthorModel>> GetAll()
    {
        List<AuthorModel> authors = await _context.Authors.ToListAsync() ?? throw new Exception("My ng there's no author yet...");
        return authors;
        
    }

    public async Task<AuthorModel> GetById(Guid guid)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == guid) ?? throw new Exception("Didnt found this guy");
        return author;
    }

    public async Task<AuthorModel> Update(Guid guid, AuthorModel author)
    {
        var updateAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == guid) ?? throw new Exception("No author");
        updateAuthor.Name = author.Name;

        _context.Authors.Update(updateAuthor);
        await _context.SaveChangesAsync();
        return updateAuthor;
    }
      public async Task Delete(Guid guid)
    {
        var deleteAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == guid) ?? throw new Exception("No author");
        
        _context.Remove(deleteAuthor);
        await _context.SaveChangesAsync();
    }

}