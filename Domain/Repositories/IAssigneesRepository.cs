using Domain.Entities.Accounts;
using Domain.Entities.Requests;

namespace Domain.Repositories
{
    public interface IAssigneesRepository : IGenericRepository<ProcessByAssignees>
    {
        Task<Account?> GetAssigneesByAccountId(string accountId);
        Task<ProcessByAssignees?> GetByAssigneeHandleRequest(string assigneesId , Guid requestId);
        Task<List<ProcessByAssignees>?> GetListByAssigneeHandleRequest(string assigneesId, Guid requestId);
    }
}

