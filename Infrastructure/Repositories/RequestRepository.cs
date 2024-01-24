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

        //show list request sorting moi nhat
        public async Task<IEnumerable<Request?>> GetAllRequest()
        {
            var list = await _dbContext.Set<Request>()
              .Include(u => u.RequestStatus)
              .Include(i => i.Account)
              .OrderByDescending(cu => cu.CreatedAt)
              .ToListAsync();
            return list;
        }

        //search fulname of request list 
        public async Task<IEnumerable<Request?>> SearchRequestsAsync
            (string search)
        {
            var keySearch = await _dbContext.Set<Request>()
                .Include(i => i.Account)
                .Where(k => k.Account.FullName.Contains(search) ||
                         k.Account.Email.Contains(search))
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return keySearch;
        }



        //show list request sorting cu nhat
        public async Task<IEnumerable<Request>> SortingRequest()
        {
            var list = await _dbContext.Set<Request>()
                .Include(u => u.RequestStatus)
                .Include(i => i.Account)
                .OrderBy(cu => cu.CreatedAt)
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

