using System.Threading;

namespace Domain.Repositories
{
    public interface IUnitOfWorkRepository
    {
        IAccountRepository accountRepo { get; }
        IRoleRepository roleRepo { get; }
        IRoleTypeRepository roleTypeRepo { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
