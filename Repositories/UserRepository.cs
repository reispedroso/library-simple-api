using System.Web.Http.Results;
using Ecc.Context;
using Ecc.Integration;
using Ecc.Models;
using Ecc.Repositories.Interfaces;
using Ecc.Services;
using Microsoft.EntityFrameworkCore;
namespace Ecc.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly PasswordHashService _passwordHash;
        private readonly IViaCepIntegration _viaCepIntegration;
        public UserRepository(AppDbContext context, PasswordHashService passwordHash, IViaCepIntegration viaCepIntegration)
        {
            _context = context;
            _passwordHash = passwordHash;
            _viaCepIntegration = viaCepIntegration;
        }
        public async Task<UserModel> CreateUserAsync(UserModel userModel)
        {
            var user = new UserModel
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = _passwordHash.HashPassword(userModel.Password!),
                Cep = userModel.Cep
            };
            var cepDetails = await _viaCepIntegration.GetCepDetails(userModel.Cep);
            var location = new LocationModel
            {
                Cep = cepDetails.Cep,
                Logradouro = cepDetails.Logradouro,
                Bairro = cepDetails.Bairro,
                Localidade = cepDetails.Localidade,
                Uf = cepDetails.Uf,
                Ddd = cepDetails.Ddd
            };
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            user.LocationId = location.LocationId;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<UserModel> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<UserModel> UpdateUserAsync(Guid userId, UserModel updatedUser)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(e => e.Id == userId);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = _passwordHash.HashPassword(updatedUser.Password!);

            await _context.SaveChangesAsync();

            return existingUser;
        }
        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var deleteThisUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (deleteThisUser == null)
            {
                return false;
            }
            _context.Users.Remove(deleteThisUser);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
