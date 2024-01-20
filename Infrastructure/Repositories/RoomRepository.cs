using Domain.Entities.Departments;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class RoomRepository: GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(OHDDbContext dbContext)
                   : base(dbContext) { }

        public Task<Room?> GetRoomById(Guid id)
        {
            var room = _dbContext.Set<Room>().SingleOrDefaultAsync(d => d.Id == id);
            return room;
        }
    }
}
