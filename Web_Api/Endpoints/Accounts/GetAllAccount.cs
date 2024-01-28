﻿using Application.UseCases.Accounts.Queries.GetAllAccount;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Accounts
{
    public class GetAllAccount : EndpointBaseAsync
        .WithRequest<FieldSSFP>
        .WithActionResult<Result>
    {
        private readonly IMediator Sender;

        public GetAllAccount(IMediator sender)
        {
            Sender = sender;
        }

        [HttpGet("api/accounts/getAll")]
        public async override Task<ActionResult<Result>> HandleAsync(
            [FromQuery] FieldSSFP request,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send( new GetAllAccountQuery(request.SearchTerm, request.SortColumn, request.SortOrder, request.Page, request.Limit) );
            return Ok(status);
        }
    }

    public class FieldSSFP
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page {  get; set; }
        public int Limit {  get; set; }
    }
}