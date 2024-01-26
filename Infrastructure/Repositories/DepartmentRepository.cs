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
    public sealed class DepartmentRepository: GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(OHDDbContext dbContext)
            : base(dbContext) { }

        public async Task<IEnumerable<Department?>> GetAllDepartment()
        {
            var list = await _dbContext.Set<Department>()
              .Include(r => r.Rooms)
              .ToListAsync();
            return list;
        }

        public Task<Department?> GetDepartmentById(Guid id)
        {
            var department = _dbContext.Set<Department>().SingleOrDefaultAsync(d => d.Id == id);
            return department;
        }
    }
}
