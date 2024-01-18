using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public sealed class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly OHDDbContext _dbContext;
        public IAccountRepository accountRepo {  get; private set; }

        public UnitOfWorkRepository(OHDDbContext dbContext)
        {
            _dbContext = dbContext;
            accountRepo = new AccountRepository(dbContext);
        }


        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
