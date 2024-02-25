using Application.UseCases.Requests.Queries.GetAllClientRequest;
using Application.UseCases.Requests.Queries.GetAllRequestWithoutSSFP;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using System.Security.Claims;

namespace Web_Api.Endpoints.Requests
{
    public class GetAllRequestWithoutSSFP: EndpointBaseAsync
        .WithRequest<GetAllRequestWithoutSSFPQueries>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetAllRequestWithoutSSFP(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request_withoutssfp")]
        [Authorize]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromRoute] GetAllRequestWithoutSSFPQueries request,
            CancellationToken cancellationToken = default)
        {
            var accountId = User.FindFirstValue(ClaimTypes.Sid);

            var status = await Sender.Send(new GetAllRequestWithoutSSFPQueries(accountId));
            return Ok(status);
        }
    }
}
