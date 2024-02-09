using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Entities.Requests;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Commands.CreateRequest
{
    public sealed class CreateRequestHandler : ICommandHandler<CreateRequestCommand>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMapper _mapper;
        public CreateRequestHandler(IUnitOfWorkRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {

            RequestResponse? resultObject = null;

            var accountId = await _repo.accountRepo.GetByAccountId(request.AccountId);
            if(accountId != null)
            {
                int requestStatusId = 1;

                var requestData = new Request
                {
                    AccountId = request.AccountId,
                    RoomId = request.RoomId,
                    RequestStatusId = requestStatusId,
                    Description = request.Description,
                    SeveralLevel = request.SeveralLevel,
                    Reason = "",
                    Enable = true,
                    CreatedAt = DateTime.UtcNow
                };
                _repo.requestRepo.Add(requestData);
                resultObject = _mapper.Map<RequestResponse>(requestData);
            }
            else
            {
                Error error = new("Error.RequestCommandHandler", "There is an error saving data!");
                return Result.Failure(error, "Create request failed!");
            }

            // test thu truowng hop Request model luon
            try
            {
                await _repo.SaveChangesAsync(cancellationToken);

                return Result.Success(resultObject, "Create request successfully!");
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
