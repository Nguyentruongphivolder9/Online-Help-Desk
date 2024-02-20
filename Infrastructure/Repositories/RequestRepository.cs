using System.Linq.Expressions;
using Application.DTOs.Requests;
using Domain.Entities.Accounts;
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
                    .Where(a => a.Account!.FullName.Contains(searchTerm) ||
                                a.Account.Email.Contains(searchTerm))
                    .OrderByDescending(a => a.CreatedAt);
            }

            Expression<Func<Request, object>> keySelector = sortColumn?.ToLower() switch
            {
                "CreatedAt" => request => request.CreatedAt,
                "RequestStatusId" => request => request.RequestStatusId ,
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
              .Include(r => r.Room).ThenInclude(de => de!.Departments)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return new DataResponse<Request>
            {
                Items = requests, // Change from 'request' to 'requests'
                TotalCount = totalCount,
            };
        }

        public async Task<DataResponse<Request>> GetAllClientEnableRequestSSFP(string? accountId , 
            string? FCondition, string? SCondition, string? TCondition, 
            string? searchTerm, string? sortColumn, string? sortOrder, int page, int limit, CancellationToken cancellationToken)
        {

            IQueryable<Request> requestQuery = _dbContext.Set<Request>();

            if (!string.IsNullOrEmpty(accountId))
            {
                requestQuery = requestQuery.Where(r => r.AccountId == accountId && r.Enable == true);
            }

            if (!string.IsNullOrEmpty(FCondition))
            {
                requestQuery = requestQuery.Where(r => r.Room!.Departments!.DepartmentName.Contains(FCondition));
            }

            if (!string.IsNullOrEmpty(SCondition))
            {
                requestQuery = requestQuery.Where(r => r.SeveralLevel.Contains(SCondition));
            }

            if (!string.IsNullOrEmpty(TCondition))
            {
                requestQuery = requestQuery.Where(r => r.RequestStatus!.StatusName.Contains(TCondition));
            }


            if (!string.IsNullOrEmpty(searchTerm))
            {
                requestQuery = requestQuery.Where(r => 
                r.SeveralLevel.Contains(searchTerm) || 
                r.Room!.Departments!.DepartmentName.Contains(searchTerm)||
                r!.RequestStatus!.StatusName.Contains(searchTerm));
   
            }

            Expression<Func<Request, object>> keySelector = sortColumn?.ToLower() switch
            {
                "department" => request => request.Room!.Departments!.DepartmentName,
                "reason" => request => request.Reason,
                "status" => request => request!.RequestStatus!.StatusName!,
                "description" => request => request.Description,
                "severallevel" => request => request.SeveralLevel,
                "createdAt" => request => request.CreatedAt,
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
              .Include(r => r.Room).ThenInclude(de => de.Departments)
              .Include(rm => rm.Remarks)
               .Skip((page - 1) * limit)
               .Take(limit)
               .ToListAsync();

            return new DataResponse<Request>
            {
                Items = requests, // Change from 'request' to 'requests'
                TotalCount = totalCount,
            };
        }

        public async Task<DataResponse<Request>> GetAllClientUnenableRequestSSFP(string? accountId,
            string? FCondition, string? SCondition, string? TCondition,
            string? searchTerm, string? sortColumn, string? sortOrder, int page, int limit, CancellationToken cancellationToken)
        {


            IQueryable<Request> requestQuery = _dbContext.Set<Request>();

            if (!string.IsNullOrEmpty(accountId))
            {
                requestQuery = requestQuery.Where(r => r.AccountId == accountId && r.Enable == false);
            }

            if (!string.IsNullOrEmpty(FCondition))
            {
                requestQuery = requestQuery.Where(r => r.Room!.Departments!.DepartmentName.Contains(FCondition));
            }

            if (!string.IsNullOrEmpty(SCondition))
            {
                requestQuery = requestQuery.Where(r => r.SeveralLevel.Contains(SCondition));
            }

            if (!string.IsNullOrEmpty(TCondition))
            {
                requestQuery = requestQuery.Where(r => r.RequestStatus!.StatusName.Contains(TCondition));
            }


            if (!string.IsNullOrEmpty(searchTerm))
            {
                requestQuery = requestQuery.Where(r =>
                r.SeveralLevel.Contains(searchTerm) ||
                r.Room.Departments!.DepartmentName.Contains(searchTerm) ||
                r!.RequestStatus!.StatusName.Contains(searchTerm));

            }

            Expression<Func<Request, object>> keySelector = sortColumn?.ToLower() switch
            {
                "department" => request => request.Room.Departments.DepartmentName,
                "reason" => request => request.Reason,
                "status" => request => request.RequestStatus.StatusName,
                "description" => request => request.Description,
                "severallevel" => request => request.SeveralLevel,
                "createdAt" => request => request.CreatedAt,
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
              .Include(r => r.Room).ThenInclude(de => de.Departments)
              .Include(rm => rm.Remarks)
               .Skip((page - 1) * limit)
               .Take(limit)
               .ToListAsync();

            return new DataResponse<Request>
            {
                Items = requests, // Change from 'request' to 'requests'
                TotalCount = totalCount,
            };
        }
        

        public async Task<RequestCountRespone?> GetCountRequest()
        {
            var CountAll = await _dbContext.Set<Request>()
                 .CountAsync();

            var CountOpen = await _dbContext.Set<Request>()
                .Where(u => u.RequestStatusId == 1)
                .CountAsync();

            var CountAssigned = await _dbContext.Set<Request>()
                .Where(u => u.RequestStatusId == 2)
                .CountAsync();
            var CountWork = await _dbContext.Set<Request>()
                .Where(u => u.RequestStatusId == 3)
                .CountAsync();
            var CountNeed = await _dbContext.Set<Request>()
              .Where(u => u.RequestStatusId == 4)
                .CountAsync();
            var CountRejected = await _dbContext.Set<Request>()
              .Where(u => u.RequestStatusId == 5)
                .CountAsync();
            var CountComplete = await _dbContext.Set<Request>()
              .Where(u => u.RequestStatusId == 6)
                .CountAsync();

            var fiveDaysAgo = DateTime.Now.AddHours(-1);

            var pendingCount = await _dbContext.Set<Request>()
                .Where(r => r.CreatedAt <= fiveDaysAgo
                && !new[] {6,7}.Contains(r.RequestStatusId)
                ) // Ensure CreatedAt is older than 10 days ago
                .CountAsync();
            return new RequestCountRespone
            {
                All = CountAll,
                Open = CountOpen,
                Assigned = CountAssigned,
                WorkInProgress = CountWork,
                NeedMoreInfo = CountNeed,
                Rejected = CountRejected,
                Complete = CountComplete,
                Pending = pendingCount
            };
        }


        public async Task<List<Request>> GetAllRequestWithoutSSFP(string accountId)
        {
            var list = await _dbContext.Set<Request>()
                .Where(r => r.AccountId == accountId)
                .Include(u => u.RequestStatus)
                .Include(i => i.Account)
                .Include(r => r.Room).ThenInclude(de => de.Departments)
                .Include(r => r.Remarks.OrderByDescending(rm => rm.CreateAt))
                .ToListAsync();

            return list;
        }

        public async Task<RequestCountRespone?> GetCountRequestByAssignees(string id)
        {
            var CountAll = await _dbContext.Set<Request>()
                .Where(r => r.ProcessByAssignees!.Any(pa => pa.AccountId == id))
                .CountAsync();

            var CountOpen = await _dbContext.Set<Request>()
                .Where(u => u.RequestStatusId == 1 && u.ProcessByAssignees!.Any(pa => pa.AccountId == id))
                .CountAsync();

            var CountAssigned = await _dbContext.Set<Request>()
                .Where(u => u.RequestStatusId == 2 && u.ProcessByAssignees!.Any(pa => pa.AccountId == id))
                .CountAsync();
            var CountWork = await _dbContext.Set<Request>()
                .Where(u => u.RequestStatusId == 3 && u.ProcessByAssignees!.Any(pa => pa.AccountId == id))
                .CountAsync();
            var CountNeed = await _dbContext.Set<Request>()
              .Where(u => u.RequestStatusId == 4 && u.ProcessByAssignees!.Any(pa => pa.AccountId == id))
                .CountAsync();
            var CountRejected = await _dbContext.Set<Request>()
              .Where(u => u.RequestStatusId == 5 && u.ProcessByAssignees!.Any(pa => pa.AccountId == id)) 
                .CountAsync();
            var CountComplete = await _dbContext.Set<Request>()
              .Where(u => u.RequestStatusId == 6 && u.ProcessByAssignees!.Any(pa => pa.AccountId == id))
                .CountAsync();

            var fiveDaysAgo = DateTime.Now.AddHours(-120);

            var pendingCount = await _dbContext.Set<Request>()
                .Where(r => r.CreatedAt <= fiveDaysAgo
                && !new[] { 6, 7 }.Contains(r.RequestStatusId)
                && r.ProcessByAssignees!.Any(pa => pa.AccountId == id)
                ) // Ensure CreatedAt is older than 10 days ago
                .CountAsync();

            return new RequestCountRespone
            {
                All = CountAll,
                Open = CountOpen,
                Assigned = CountAssigned,
                WorkInProgress = CountWork,
                NeedMoreInfo = CountNeed,
                Rejected = CountRejected,
                Complete = CountComplete,
                Pending = pendingCount
            };
        }
    }
}

