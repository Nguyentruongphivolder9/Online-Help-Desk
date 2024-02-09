using Application.UseCases.Requests.Queries.GetAllClientRequest;
using Application.UseCases.Requests.Queries.GetAllRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class GetAllClientRequest : EndpointBaseAsync
        .WithRequest<FieldSSFPClient>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetAllClientRequest(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/request")]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromQuery] FieldSSFPClient request,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send
                (new GetAllClienRequestQueries(
                request.SearchTerm, request.SortColumn,
                request.SortOrder, request.Page, request.Limit));
            return Ok(status);
        }
    }
    public class FieldSSFPClient
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }

}
