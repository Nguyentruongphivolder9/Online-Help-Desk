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
            if (oldRequest == null)
            {
                return Result.Failure(new Error("Error", "No data exists"), "Can not GetRequestById ");
            }
            oldRequest.RequestStatusId = request.RequestStatusID;
            _repo.requestRepo.Update(oldRequest);
            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                return Result.Success("Updated request successfully by Facility-Header ");
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
