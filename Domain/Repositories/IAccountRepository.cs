using Domain.Entities.Accounts;

namespace Domain.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account> 
    {
        Task<Account?> GetByEmail(string email);
        Task<Account?> GetByPhoneNumber(string phone);
        Task<Account?> GetByAccountId(string accountId);
    }
}
