using Application.Common.Messaging;
using Domain.Entities.Requests;
using Domain.Repositories;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Requests.Commands.UpdateRequest
{
    public sealed class UpdateRequestCommandHandler: ICommandHandler<UpdateRequestCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public UpdateRequestCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var oldRequest = await _repo.requestRepo.GetRequestById(request.Id);
            var account = await _repo.accountRepo.GetByAccountId(request.AccountId);


            if (oldRequest == null)
            {
                return Result.Failure(new Error("Error", "No data exists"), "Can not GetRequestById ");
            }

            if (account.Role.RoleTypeId == 1) // End-User
            {
                if (request.Enable.HasValue && !(request.RequestStatusId.HasValue))
                {
                    oldRequest.Enable = (bool)request.Enable;
                    oldRequest.RequestStatusId = oldRequest.RequestStatusId;
                    oldRequest.UpdateAt = DateTime.UtcNow;
                }
            }
            else if(
                account.Role.RoleTypeId == 2 || 
                account.Role.RoleTypeId == 3 || 
                account.Role.RoleTypeId == 4) // Facility, Assignees , Admin
            {
                if (request.RequestStatusId.HasValue && !(request.Enable.HasValue))
                {
                    oldRequest.Enable = oldRequest.Enable;
                    oldRequest.RequestStatusId = (int)request.RequestStatusId;
                    oldRequest.UpdateAt = DateTime.UtcNow;
                }
            }
         
            _repo.requestRepo.Update(oldRequest);
            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                if (account.Role.RoleTypeId == 2 || account.Role.RoleTypeId == 3 || account.Role.RoleTypeId == 4)
                {
                    return Result.Success("Updated request successfully by Facility-Header ");
                }
                else {
                    return Result.Success("You have archived a request successfully");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.UpdateCommandHandler", "There is an error saving data!");
                return Result.Failure(error, "Update request failed by Facility-Header ");
            }

        }
    }
}
