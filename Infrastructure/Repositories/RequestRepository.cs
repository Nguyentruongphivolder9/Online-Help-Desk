using System;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(OHDDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Request?>> GetAllRequest()
        {
            var list = await _dbContext.Set<Request>()
                .Include(u => u.RequestStatus)
                .Include(i => i.Account)
                .ToListAsync();
            return list;
        }

        public async Task<Request?> GetRequestById(Guid id)
        {
            var requestObj = await _dbContext.Set<Request>().SingleOrDefaultAsync(r => r.Id == id);
            return requestObj;
        }

    }
}

