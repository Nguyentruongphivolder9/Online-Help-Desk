using Application.UseCases.Accounts.Commands.SendMailVerifyCode;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;

namespace Web_Api.Endpoints.Auth
{
    public class SendMail : EndpointBaseAsync
    .WithRequest<SendMailVerifyCodeCommand>
    .WithActionResult<Result>
    {

        private readonly IMediator Sender;

        public SendMail(IMediator sender)
        {
            Sender = sender;
        }


        [HttpPost("api/auth/send-mail")]
        public override async Task<ActionResult<Result>> HandleAsync(
            SendMailVerifyCodeCommand command,
            CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(command);
            return Ok(status);
        }
    }
}
