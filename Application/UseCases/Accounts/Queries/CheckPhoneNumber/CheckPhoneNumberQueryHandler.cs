using Application.Common.Messaging;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Queries.CheckPhoneNumber
{
    public sealed class CheckPhoneNumberQueryHandler : IQueryHandler<CheckPhoneNumberQuery>
    {
        private readonly IUnitOfWorkRepository _repo;

        public CheckPhoneNumberQueryHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(CheckPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var acc = await _repo.accountRepo.GetByPhoneNumber(request.PhoneNumber);
            if (acc != null)
                return Result.Failure(new Error("Error.Client", "data duplication"), "Phone number already exists.");

            return Result.Success("Valid phone number.");
        }
    }
}
