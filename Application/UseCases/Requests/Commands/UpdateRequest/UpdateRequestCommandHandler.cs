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
            Guid id = request.Id;
            var oldRequest = await _repo.requestRepo.GetRequestById(id);
            if (oldRequest == null)
            {
                return Result.Failure(new Error("Error", "No data exists"), "Request does not exists");
            }
            oldRequest.Reason = request.Reason;
            oldRequest.SeveralLevel = request.SeveralLevel;
            oldRequest.Description = request.Description;
            _repo.requestRepo.Update(oldRequest);

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                return Result.Success("Updated request successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.UpdateCommandHandler", "There is an error saving data!");
                return Result.Failure(error, "Update request failed");
            }

        }
    }
}
