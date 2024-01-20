using System.Threading;

namespace Domain.Repositories
{
    public interface IUnitOfWorkRepository
    {

        IAccountRepository accountRepo { get; }
        IRequestRepository requestRepo { get; }
        IRoleRepository roleRepo { get; }
        IRoleTypeRepository roleTypeRepo { get; }
        IRequestRepository requestRepo { get; }
        IDepartmentRepository departmentRepo { get; }
        IRoomRepository roomRepo { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
