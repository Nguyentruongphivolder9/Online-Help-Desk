using Application.UseCases.Accounts.Queries.GetAllRoleType;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Accounts
{
    public class GetAllRole : EndpointBaseAsync
        .WithRequest<GetAllRoleTypeQuery>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetAllRole(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/accounts/role-type/get-all")]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromQuery] GetAllRoleTypeQuery request,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(new GetAllRoleTypeQuery());
            return Ok(status);
        }
    }
}
