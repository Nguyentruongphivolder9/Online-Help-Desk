using System;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;

namespace Domain.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        Task<IEnumerable<Request?>> GetAllRequest();
        Task<IEnumerable<Request?>> SortingRequest();
        Task<IEnumerable<Request?>> SearchRequestsAsync(string keySearch);
        Task<Request?> GetRequestById(Guid id);
    }
}

