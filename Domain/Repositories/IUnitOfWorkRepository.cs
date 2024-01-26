namespace Domain.Repositories
{
    public interface IUnitOfWorkRepository
    {

        IAccountRepository accountRepo { get; }
        IRequestRepository requestRepo { get; }
        IRoleRepository roleRepo { get; }
        IRoleTypeRepository roleTypeRepo { get; }
        IDepartmentRepository departmentRepo { get; }
        IRoomRepository roomRepo { get; }
        IAssigneesRepository assigneesRepo { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
