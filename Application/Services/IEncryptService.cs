namespace Application.Services
{
    public interface IEncryptService
    {
        bool EncryptPassword(string password, string passwordHash);
    }
}
