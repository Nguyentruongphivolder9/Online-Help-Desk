using Domain.Entities.Accounts;
using SharedKernel;

namespace Domain.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account> 
    {
        Task<Account?> GetByEmail(string email);
        Task<Account?> GetByPhoneNumber(string phone);
        Task<Account?> GetByAccountId(string accountId);
        Task<Account?> CheckVerifyCode(string verifyCode);
        Task<DataResponse<Account>> GetAllAccountSSFP(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken cancellationToken);
    }
}
