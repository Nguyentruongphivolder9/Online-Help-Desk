using Application.Common.Messaging;
using Domain.Entities.Requests;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Commands.CreateRequest
{
    public sealed class CreateRequestHandler : ICommandHandler<CreateRequestCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public CreateRequestHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var requestData = new Request
            {
                AccountId = request.AccountId,
                RoomId = request.RoomId,
                RequestStatusId = request.RequestStatusId,
                Description = request.Description,
                SeveralLevel = request.SeveralLevel,
                Reason = request.Reason,
                Enable= true,
                CreatedAt = DateTime.UtcNow
            };

            var accountId = await _repo.accountRepo.GetByAccountId(request.AccountId);
            if(accountId != null)
            {
                _repo.requestRepo.Add(requestData);
            }

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);

                return Result.Success("Create request successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.RequestCommandHandler", "There is an error saving data!");
                return Result.Failure(error, "Create request failed!");
            }



        }
    }
}
