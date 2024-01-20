using Application.UseCases.Request.Commands.CreateRequest;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class CreateRequest : EndpointBaseAsync
        .WithRequest<CreateRequestCommand>
        .WithActionResult<Result>
    {
        public override Task<ActionResult<Result>> HandleAsync(CreateRequestCommand request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
