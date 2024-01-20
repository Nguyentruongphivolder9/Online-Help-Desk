using Domain.Entities.Departments;

namespace Domain.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<Department?> GetDepartmentById(Guid id);  

    }
}
