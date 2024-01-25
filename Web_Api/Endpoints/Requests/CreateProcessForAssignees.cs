
using Application.UseCases.Requests.Commands.CreateProcessForAssignees;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class CreateProcessForAssignees : EndpointBaseAsync
     .WithRequest<CreateProcessCommand>
     .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public CreateProcessForAssignees(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPost("api/request/CreateProcessForAssignees")]
        public async override Task<ActionResult<Result>> HandleAsync(
            CreateProcessCommand command,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(command);
            return status;
        }
    }
}

