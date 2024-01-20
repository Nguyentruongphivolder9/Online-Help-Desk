using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class RequestRepository : GenericRepository<Request>, IRequestRepository
    {

        public RequestRepository(OHDDbContext dbContext)
            : base(dbContext) { }

        public Task<Request> CreateRequest(Request body)
        {
            throw new NotImplementedException();
        }
    }
}
