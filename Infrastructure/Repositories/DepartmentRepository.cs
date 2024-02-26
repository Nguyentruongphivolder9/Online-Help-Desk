using Domain.Entities.Departments;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<Department?> GetDepartmentByName(string departmentName)
        {
            var result = _dbContext.Set<Department>()
                .SingleOrDefaultAsync(d => d.DepartmentName == departmentName);
            return result;
        }

        public async Task<DataResponse<Department>> GetListDepartmentSSFP(string? searchTerm, int page, int pageSize, CancellationToken cancellationToken)
        {
            IQueryable<Department> departmentQuery = _dbContext.Set<Department>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                departmentQuery = departmentQuery.Where(a =>
                    a.DepartmentName.Contains(searchTerm)
                );
            }

            var totalCount = await departmentQuery.CountAsync();

            var departments = await departmentQuery
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return new DataResponse<Department>
            {
                Items = departments,
                TotalCount = totalCount,
            };
        }
    }
}
