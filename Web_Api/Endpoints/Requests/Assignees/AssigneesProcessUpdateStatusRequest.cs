﻿using Application.UseCases.Requests.Commands.ProcessUpdateStatusRequest;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests.Assignees
{
    public class AssigneesProcessUpdateStatusRequest : EndpointBaseAsync
     .WithRequest<ProcessUpdateStatusRequestCommand>
     .WithActionResult<Result>
    {

        private readonly IMediator Sender;

        public AssigneesProcessUpdateStatusRequest(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPut("api/request/update-status")]
        [Authorize(Roles = "Assignees")]
        public override async Task<ActionResult<Result>> HandleAsync(
            ProcessUpdateStatusRequestCommand command, 
            CancellationToken cancellationToken = default
        ) {
            var status = await Sender.Send(command);
            return status;
        }
    }
}
