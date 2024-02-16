using System;
using Application.UseCases.Requests.Queries.GetListRequestByReStatusId;
using Application.UseCases.Requests.Queries.GetRequestById;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
	public class GetListRequestByReStatusId : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetListRequestByReStatusId(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request/requestStatusId={id}")]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromRoute] int id,
            CancellationToken cancellationToken = default)
        {
            var cu = new GetListRequestByReStatusIdQueries { Id = id };
            var status = await Sender.Send(cu);
            return Ok(status);
        }
    }
}

