using Application.UseCases.Requests.Queries.GetAllRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class GetAllRequest : EndpointBaseAsync
        .WithRequest<GetAllRequestQueries>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetAllRequest(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request/getAll")]
        public async override Task<ActionResult<Result>> HandleAsync

            ([FromQuery]
            GetAllRequestQueries request,

            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(request);
            return Ok(status);
        }
    }
}

