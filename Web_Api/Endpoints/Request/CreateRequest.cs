using Application.UseCases.Request.Commands.CreateRequest;
using Ardalis.ApiEndpoints;
using SharedKernel;

namespace Web_Api.Endpoints.Request
{
    public class CreateRequest: EndpointBaseAsync
        .WithRequest<CreateRequestCommand>
        .WithActionResult<Result>
    {
    }
}
