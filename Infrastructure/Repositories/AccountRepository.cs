using Domain.Entities.Accounts;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Infrastructure.Repositories
{
    public sealed class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
       public AccountRepository(OHDDbContext dbContext) 
            : base(dbContext) { }

        public Task<Account?> CheckVerifyCode(string verifyCode)
        {
            throw new NotImplementedException();
        }

        public async Task<Account?> GetByAccountId(string accountId)
        {
            var user = await _dbContext.Set<Account>()
                .Include(a => a.Role)
                .ThenInclude(c => c.RoleTypes)
                .SingleOrDefaultAsync(u => u.AccountId == accountId);
            return user;
        }

        public async Task<Account?> GetByEmail(string email)
        {
            var user = await _dbContext.Set<Account>().SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<Account?> GetByPhoneNumber(string phone)
        {
            var user = await _dbContext.Set<Account>().SingleOrDefaultAsync(u => u.PhoneNumber == phone);
            return user;
        }
    }
}
