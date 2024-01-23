using Application.UseCases.Requests.Queries.GetRequestById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class GetRequestById : EndpointBaseAsync
        .WithRequest<GetRequestByIdQueries>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetRequestById(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request/{id:guid}")]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromQuery] GetRequestByIdQueries request, CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(request);
            return Ok(status);
        }
    }
}
