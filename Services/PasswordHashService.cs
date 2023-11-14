
namespace Ecc.Services
{
    public class PasswordHashService
    {
        public string HashPassword (string password) 
        {
            string hashedPassword = BC.HashPassword(password);
            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BC.Verify(password, hashedPassword);
        }
    }
}
