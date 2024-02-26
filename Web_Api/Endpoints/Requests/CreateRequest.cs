using Application.UseCases.Requests.Commands.CreateRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class CreateRequest : EndpointBaseAsync
     .WithRequest<CreateRequestCommand>
     .WithActionResult<Result>
    {

        private readonly IMediator Sender;

        public CreateRequest(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPost("api/request/create_request")]
        //[Authorize(Roles = "End-Users")]
        public override async Task<ActionResult<Result>> HandleAsync(CreateRequestCommand command, CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(command);
            return status;
        }
    }
}