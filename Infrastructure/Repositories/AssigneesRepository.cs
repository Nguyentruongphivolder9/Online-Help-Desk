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
            var processRequest = await _dbContext.ProcessByAssignees.SingleOrDefaultAsync
                (u => u.AccountId == assigneesId && u.RequestId == requestId);
            return processRequest;    
        }

        //show all list assigness
        public async Task<IEnumerable<ProcessByAssignees?>> GetListAssignees()
        {
            var listAssignees = await _dbContext.Set<ProcessByAssignees>()
                .Include(i => i.Account)
                .Include( acc => acc.Account)
                .ToListAsync();
            return listAssignees;
        }
    }
}

