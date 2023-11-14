using Ecc.Models;

namespace Ecc.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel> GetUserByEmail(string email);
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> UpdateUserAsync(Guid userId, UserModel updateUser);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
