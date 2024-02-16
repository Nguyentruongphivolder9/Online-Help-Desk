using Application.Common.Messaging;
using Application.DTOs.Requests;
using AutoMapper;
using Domain.Entities.Requests;
using Domain.Repositories;
using Newtonsoft.Json;
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
            Guid roomId = new Guid(request.RoomId);
            var account= await _repo.accountRepo.GetByAccountId(request.AccountId);

            if (account != null) {
                var existedUnprocessedRequestOnRoom = account.Requests.
                                 Where(r => r.RoomId == roomId)
                                .Where(r=> r.RequestStatusId != 5 && r.RequestStatusId != 6 && r.RequestStatusId !=7)
                                .FirstOrDefault();
                if (existedUnprocessedRequestOnRoom != null)
                {
                    Error error = new("Error.RequestCommandHandler", "You have a unprocessed requet on this room. Please wait!");
                    return Result.Failure(error, "Create request failed!");
                }
            }
          
            
            if(account != null)
            {
                int requestStatusId = 1;

                var requestData = new Request
                {
                    AccountId = request.AccountId,
                    RoomId = roomId,
                    RequestStatusId = requestStatusId,
                    Description = request.Description,
                    SeveralLevel = request.SeveralLevel,
                    Reason = "",
                    Date= request.Date != null ? request.Date : null,
                    Enable = true,
                    CreatedAt = DateTime.Now
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
