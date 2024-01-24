
using System;
using Application.UseCases.Requests.Queries.GetAllRequest;
using Application.UseCases.Requests.Queries.SortingRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class SortingRequest : EndpointBaseAsync
        .WithRequest<SortingRequestQueries>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public SortingRequest(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request/SortingOldRequest")]
        public async override Task<ActionResult<Result>> HandleAsync
            ([FromQuery]
            SortingRequestQueries request,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(request);
            return Ok(status);
        }
    }
}

