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
            var listfacilityHeads = await _repo.accountRepo.GetAllFacilityHeads();

            //check duplicate request on a room(spam request)
            if (account != null) {
                var existedUnprocessedRequestOnRoom = account.Requests!.
                                 Where(r => r.RoomId == roomId)
                                .Where(r=> r.RequestStatusId != 5 && r.RequestStatusId != 6 && r.RequestStatusId !=7)
                                .FirstOrDefault();
                if (existedUnprocessedRequestOnRoom != null)
                {
                    Error error = new("Error.RequestCommandHandler", "You have a unprocessed requet on this room. Please wait!");
                    return Result.Failure(error, "Create request failed!");
                }
            }

            var requestData = new Request
            {
                Id = new Guid(),
                AccountId = request.AccountId,
                RoomId = roomId,
                RequestStatusId = 1,
                Description = request.Description,
                SeveralLevel = request.SeveralLevel,
                Reason = "",
                Date= request.Date != null ? request.Date : null,
                Enable = true,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            };
            _repo.requestRepo.Add(requestData);
            resultObject = _mapper.Map<RequestResponse>(requestData);


            //creat notification for facility-heads 
            foreach (var item in listfacilityHeads)
            {
                var notificationHandleRequest = new NotificationHandleRequest
                {
                    Id = new Guid(),
                    RequestId = requestData.Id,
                    AccountId = item.AccountId,
                    Purpose = "Create new Request",
                    IsSeen = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _repo.notificationHandleRequestRepo.Add(notificationHandleRequest);

                var notificationRemark = new Domain.Entities.Requests.NotificationRemark
                {
                    Id = new Guid(),
                    RequestId = requestData.Id,
                    AccountId = item.AccountId,
                    IsSeen = true,  
                    Unwatchs = 0,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _repo.notificationRemarkRepo.Add(notificationRemark);
            }

            //create notification for user creating request
            var notificationHandleRe = new NotificationHandleRequest
            {
                Id = new Guid(),
                RequestId = requestData.Id,
                AccountId = request.AccountId,
                Purpose = "Create new Request",
                IsSeen = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _repo.notificationHandleRequestRepo.Add(notificationHandleRe);

            var notificationRe = new Domain.Entities.Requests.NotificationRemark
            {
                Id = new Guid(),
                RequestId = requestData.Id,
                AccountId = request.AccountId,
                IsSeen = true,
                Unwatchs = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _repo.notificationRemarkRepo.Add(notificationRe);

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
