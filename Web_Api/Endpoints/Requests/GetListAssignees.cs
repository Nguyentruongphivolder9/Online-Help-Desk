using Application.UseCases.Assigness.Queries.GetAllAssignees;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class ListAssigneesRequest : EndpointBaseAsync
        .WithRequest<GetAllAssigneesQueries>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public ListAssigneesRequest(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/Assignees/GetListAssignees")]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromQuery] GetAllAssigneesQueries request,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(request);
            return Ok(status);
        }
    }
}

