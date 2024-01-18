using Application.Services;

namespace Infrastructure.Services
{
    public class EncryptService : IEncryptService
    {
        public bool EncryptPassword(string password, string passwordHash)
        {
            var result = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return result;
        }
    }
}
