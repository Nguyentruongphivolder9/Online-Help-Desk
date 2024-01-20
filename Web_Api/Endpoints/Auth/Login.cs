using Application.UseCases.Accounts.Commands.Login;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Auth
{
    //Defines a class named Login that inherits from EndpointBaseAsync and
    // is configured to handle a request of type LoginCommand
    // and return an ActionResult<Result>.
    public class Login : EndpointBaseAsync
        .WithRequest<LoginCommand>
        .WithActionResult<Result>
    {

        private readonly IMediator Sender;

        public Login(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPost("api/auth/login")]
        //Overrides the HandleAsync method from the base class(EndpointBaseAsync)
        public override async Task<ActionResult<Result>> HandleAsync(
            LoginCommand command,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(command);
            return Ok(status);
        }
    }
}
