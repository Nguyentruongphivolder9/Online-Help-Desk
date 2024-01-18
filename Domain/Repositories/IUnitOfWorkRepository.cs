using System.Threading;

namespace Domain.Repositories
{
    public interface IUnitOfWorkRepository
    {
        IAccountRepository accountRepo { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
