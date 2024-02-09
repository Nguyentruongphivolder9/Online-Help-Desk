using System;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;

namespace Domain.Repositories
{
	public interface IAssigneesRepository : IGenericRepository<ProcessByAssignees>
    {
        Task<ProcessByAssignees?> GetByAssigneeHandleRequest(string assigneesId , Guid requestId);
        Task<int> GetTotalRequestofAssignee(string AccountId);
    }
}

