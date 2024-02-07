
using Application.UseCases.Assigness.Queries.GetTotalRequest;
using Application.UseCases.Requests.Queries.GetRequestById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
	public class GetTotalRequest : EndpointBaseAsync
        .WithRequest<string>
        .WithActionResult<Result>
	{

        private readonly IMediator Sender;

        public GetTotalRequest(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/Assignees/GetTotalRequest/{id}")]
        public async override Task<ActionResult<Result>> HandleAsync(
            string id,
            CancellationToken cancellationToken = default)
        {
            var getTotalRequestQueries = new GetTotalRequestQueries { AccountId = id };
            var status = await Sender.Send(getTotalRequestQueries);
            return Ok(status);
        }

    }
}

