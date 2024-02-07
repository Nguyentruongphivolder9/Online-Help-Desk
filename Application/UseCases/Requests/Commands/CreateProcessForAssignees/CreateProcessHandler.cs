﻿using Application.Common.Messaging;
using Domain.Entities.Requests;
using Domain.Repositories;
using SharedKernel;


namespace Application.UseCases.Requests.Commands.CreateProcessForAssignees
{
    public sealed class CreateProcessHandler : ICommandHandler<CreateProcessCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public CreateProcessHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(
            CreateProcessCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _repo.accountRepo.GetByAccountId(request.AccountId);
            if (account == null )
            {
                return Result.Failure(new Error("Error.CreateProcessHandler", "Data is null!"),
                    "Account does not exsit!");
            }
            if(account.RoleId != 4)
            {
                return Result.Failure(new Error("Error.CreateProcessHandler", "RoleID is null!"),
                    "Assignees does not exsit !");
            }
            if(account.StatusAccount != "Active")
            {
                return Result.Failure(new Error("Error.CreateProcessHandler", "StatusAccount is error!"),
                    "Assignees Status is InActive or Banned  !");
            }


            var requestItem = await _repo.requestRepo.GetRequestById(request.RequestId);
            if(requestItem == null)
            {
                return Result.Failure(new Error("Error.CreateProcessHandler", "Something is null!"),
                   "Request does not exsit !");
            }

            if (requestItem.RequestStatusId != 1 || requestItem.RequestStatus.StatusName != "Open")
            {
                return Result.Failure(new Error("Error.CreateProcessHandler", "Status Name is error!"),
                   "Status Name is error !");
            }

            requestItem.RequestStatusId = request.RequestStatusId;
            requestItem.UpdateAt = DateTime.UtcNow;

            
            var processByAssignee = await _repo.assigneesRepo
                .GetByAssigneeHandleRequest(request.AccountId , request.RequestId);
            if (processByAssignee != null)
            {
                return Result.Failure(new Error("Error.CreateProcessHandler", "Something is null!"),
                   "RequestId or AccountId is duplicate !");
            }

            var processByAssigneesData = new ProcessByAssignees
            {
                RequestId = request.RequestId,
                AccountId = request.AccountId,
            };

            try
            {
                _repo.requestRepo.Update(requestItem);
                await _repo.SaveChangesAsync(cancellationToken);
                _repo.assigneesRepo.Add(processByAssigneesData);
                await _repo.SaveChangesAsync(cancellationToken);

                return Result.Success("Created request processByAssigneesData successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.CreateProcessHandler", "There is an error saving data!");
                return Result.Failure(error, "Create request processByAssigneesData FAILED !");
            }


        }
    }
}

