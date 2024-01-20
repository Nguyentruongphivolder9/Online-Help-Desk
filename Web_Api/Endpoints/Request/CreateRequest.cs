using Application.UseCases.Requests.Commands.CreateRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web_Api.Endpoints.Request
{
    public class CreateRequest: EndpointBaseAsync
        .WithRequest<CreateRequestCommand>
        .WithActionResult<Result>
    {

        private readonly IMediator Sender;

        public CreateRequest(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPost("api/request/create_request")]
        public override async Task<ActionResult<Result>> HandleAsync(CreateRequestCommand command, CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(command);
            return Ok(status);
        }
    }
}
