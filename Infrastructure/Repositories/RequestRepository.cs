using System.Linq.Expressions;
using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Repositories
{
    public sealed class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(OHDDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Request?> GetRequestById(Guid id)
        {
            var requestObj = await _dbContext.Set<Request>()
                .Include(u => u.RequestStatus)
                .Include(i => i.Account)
                .Include(r => r.Room).ThenInclude(de => de!.Departments)
                .Include(cu => cu.ProcessByAssignees!)
                .ThenInclude(i => i.Account)
                .SingleOrDefaultAsync(r => r.Id == id);
            return requestObj;
        }

        public async Task<DataResponse<Request>> GetAllRequestSSFP(string? searchTerm, string? sortColumn, string? sortOrder, int page, int pageSize, CancellationToken cancellationToken)
        {
            IQueryable<Request> requestQuery = _dbContext.Set<Request>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                requestQuery = requestQuery
                    .Include(i => i.Account)
                    .Where(a => a.Account.FullName.Contains(searchTerm) ||
                                a.Account.Email.Contains(searchTerm))
                    .OrderByDescending(a => a.CreatedAt);
            }

            Expression<Func<Request, object>> keySelector = sortColumn?.ToLower() switch
            {
                "CreatedAt" => request => request.CreatedAt,
                _ => request => request.CreatedAt
            };

            // Adjust the ordering based on sortOrder
            if (sortOrder?.ToLower() == "desc")
            {
                requestQuery = requestQuery.OrderByDescending(keySelector);
            }
            else
            {
                requestQuery = requestQuery.OrderBy(keySelector);
            }

            var totalCount = await requestQuery.CountAsync();

            var requests = await requestQuery
              .Include(u => u.RequestStatus)
              .Include(i => i.Account)
              .Include(cu => cu.ProcessByAssignees!)
              .ThenInclude(i => i.Account)
              .Include(r => r.Room).ThenInclude(de => de.Departments)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return new DataResponse<Request>
            {
                Items = requests, // Change from 'request' to 'requests'
                TotalCount = totalCount,
            };
        }

    }
}

