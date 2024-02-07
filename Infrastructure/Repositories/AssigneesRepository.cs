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

        public async Task<ProcessByAssignees?> GetByAssigneeHandleRequest(string assigneesId, Guid requestId)
        {
            var processRequest = await _dbContext.Set<ProcessByAssignees>().SingleOrDefaultAsync
                (u => u.AccountId == assigneesId && u.RequestId == requestId);
            return processRequest;    
        }

        public async Task<int> GetTotalRequestofAssignee(string AccountId)
        {
            var totalRequests = await _dbContext.Set<ProcessByAssignees>()
                .Where(u => u.AccountId == AccountId)
                .GroupBy(u => u.RequestId)
                .CountAsync()
                ;
            return totalRequests;
        }

    }
}

