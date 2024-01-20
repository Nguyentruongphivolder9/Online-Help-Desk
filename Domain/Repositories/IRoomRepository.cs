using Domain.Entities.Accounts;
using Domain.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<Room?> GetRoomById(Guid id);
    }
}
