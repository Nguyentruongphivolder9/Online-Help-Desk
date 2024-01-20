using System;
using Application.UseCases.Request.Commands.CreateRequest;
using Application.UseCases.Requests.Queries.GetAllRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

        public async override Task<ActionResult<Result>> HandleAsync
            (GetAllRequestQueries request,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(request);
            return Ok(status);
        }
    }
}

