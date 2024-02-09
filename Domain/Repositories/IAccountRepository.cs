using Domain.Entities.Accounts;
using SharedKernel;

namespace Domain.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account> 
    {
        Task<Account?> GetByEmail(string email);
        Task<Account?> GetByPhoneNumber(string phone);
        Task<Account?> GetByAccountId(string accountId);
        Task<DataResponse<Account>> GetAllAccountSSFP(string? searchTerm, string? sortColumn, string? sortOrder, string? RoleType, int page, int pageSize, CancellationToken cancellationToken);
        Task<Account?> GetStaySignIn(string accountId, string refreshToken);
        Task<bool> CheckRegisterAccount(string accountId);
    }
}
