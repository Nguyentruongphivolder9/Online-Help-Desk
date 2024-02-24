using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class AssigneesRepository : GenericRepository<ProcessByAssignees>, IAssigneesRepository
    {
        public AssigneesRepository(OHDDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<Account?> GetAssigneesByAccountId(string accountId)
        {
            var user = await _dbContext.Set<Account>()
                 .SingleOrDefaultAsync(u => u.AccountId == accountId);
            return user;
        }

        public async Task<ProcessByAssignees?> GetByAssigneeHandleRequest(string assigneesId, Guid requestId)
        {
            var processRequest = await _dbContext.Set<ProcessByAssignees>().SingleOrDefaultAsync
                (u => u.AccountId == assigneesId && u.RequestId == requestId);
            return processRequest;    
        }

        public async Task<List<ProcessByAssignees>> GetListByAssigneeHandleRequest(Guid requestId)
        {
            var listProcessRequest = await _dbContext.Set<ProcessByAssignees>().Where(ai => ai.RequestId == requestId).ToListAsync();
            return listProcessRequest;
        }
        public async Task<List<ProcessByAssignees>> GetListHandleRequestOfOneAssigneeByAccountId(string accountId)
        {
            var listProcessRequestByAccountId = await _dbContext.Set<ProcessByAssignees>().Where(ai => ai.AccountId == accountId).ToListAsync();
            return listProcessRequestByAccountId;
        }

    }
}

