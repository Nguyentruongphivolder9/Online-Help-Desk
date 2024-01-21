using Application.Common.Messaging;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Commands.Verify
{
    public sealed class VerifyCommandHandler : ICommandHandler<VerifyCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public VerifyCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public Task<Result> Handle(VerifyCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
