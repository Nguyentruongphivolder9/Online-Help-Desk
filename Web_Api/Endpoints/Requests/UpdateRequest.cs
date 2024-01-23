using Application.UseCases.Requests.Commands.UpdateRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web_Api.Endpoints.Requests
{
    public class UpdateRequest : EndpointBaseAsync
        .WithRequest<UpdateRequestCommand>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public UpdateRequest(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPut("api/request/create_request/{id:guid}")]
        public async override Task<ActionResult<Result>> HandleAsync(UpdateRequestCommand request, CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(request);
            return status;
        }
    }
}
