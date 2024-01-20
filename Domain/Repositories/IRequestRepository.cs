using Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRequestRepository: IGenericRepository<Request>
    {
        Task<Request> CreateRequest(Request body);
    }
}
