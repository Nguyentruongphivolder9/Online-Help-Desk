using Application.Common.Messaging;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Requests.Commands.ProcessUpdateStatusRequest
{
    public sealed class ProcessUpdateStatusRequestCommandHandler : ICommandHandler<ProcessUpdateStatusRequestCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public ProcessUpdateStatusRequestCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(ProcessUpdateStatusRequestCommand request, CancellationToken cancellationToken)
        {
            var resultRequest = await _repo.requestRepo.GetRequestById(request.Id);
            if (resultRequest == null)
                return Result.Failure(new Error("Error", "No data exists"), "The request does not exist in the database");

            if (resultRequest.RequestStatus!.Id == 6)
                return Result.Failure(new Error("Error", "wrong state"), "Complete processing of the user's request. Can't change the status of a request");

            if (resultRequest.RequestStatus!.Id == 5)
                return Result.Failure(new Error("Error", "wrong state"), "The request is in a rejected state. The status of the request can't be changed");

            if (
                request.RequestStatusId != 3 
                && request.RequestStatusId != 4
                && request.RequestStatusId != 5
                && request.RequestStatusId != 6
            ) return Result.Failure(new Error("Error", "wrong state"), "You can only update Work in progress, Need more info, Rejected and Completed states");

            if(request.RequestStatusId <= resultRequest.RequestStatus!.Id)
                return Result.Failure(new Error("Error", "wrong state"), "Can't go back to the old state");

            if(request.RequestStatusId == 5 && request.Reason != null)
            {
                resultRequest.Reason = request.Reason;
            }

            resultRequest.RequestStatusId = request.RequestStatusId;
            resultRequest.UpdateAt = DateTime.Now;
            _repo.requestRepo.Update(resultRequest);

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);

                return Result.Success("Update status of requestId " + request.Id + " successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.UpdateRequest", "There is an error saving data!");
                return Result.Failure(error, "Account code verification errors");
            }
        }
    }
}
