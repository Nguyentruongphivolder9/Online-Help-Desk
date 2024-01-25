using System;
using Application.UseCases.Requests.Queries.SearchRequest;
using Application.UseCases.Requests.Queries.SortingRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
	public class SearchRequest : EndpointBaseAsync
        .WithRequest<string>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public SearchRequest(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request/SearchRequest/{search}")]
        public override async Task<ActionResult<Result>> HandleAsync(
            [FromRoute] string search,
            CancellationToken cancellationToken = default)
        {
            var searchRequestQueries = new SearchRequestQueries { Search = search};
            var status = await Sender.Send(searchRequestQueries);
            return Ok(status);
        }
    }
}

