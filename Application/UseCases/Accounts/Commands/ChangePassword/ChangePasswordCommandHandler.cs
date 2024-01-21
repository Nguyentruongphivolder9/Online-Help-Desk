using Application.Common.Messaging;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    public sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public ChangePasswordCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
