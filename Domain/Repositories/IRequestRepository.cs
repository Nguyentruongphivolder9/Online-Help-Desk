using System;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using SharedKernel;

namespace Domain.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<DataResponse<Request>> GetAllRequestSSFP
            (string? searchTerm, string? sortColumn, string? sortOrder,
            int page, int pageSize, CancellationToken cancellationToken);
        Task<DataResponse<Request>> GetAllClientEnableRequestSSFP
           (string? AccountId , 
            string? FCondition, string? SCondition, string? TCondition,
            string? searchTerm, string? sortColumn, string? sortOrder,
           int page, int pageSize, CancellationToken cancellationToken);
        Task<DataResponse<Request>> GetAllClientUnenableRequestSSFP
           (string? AccountId,
            string? FCondition, string? SCondition, string? TCondition,
            string? searchTerm, string? sortColumn, string? sortOrder,
           int page, int pageSize, CancellationToken cancellationToken);
        Task<Request?> GetRequestById(Guid id);
        Task<Request?> GetRequestByRoomId(Guid id);
        Task<List<Request>> GetAllRequestWithoutSSFP(string accountId);
    }
}

