using Application.Common.Messaging;
using Application.DTOs;
using Application.Services;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Commands.SendMailVerifyCode
{
    public sealed class SendMailCommandHandler : ICommandHandler<SendMailCommand>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMailService _mailService;
        private readonly IRandomService _randomService;

        public SendMailCommandHandler(IUnitOfWorkRepository repo, IMailService mailService, IRandomService randomService)
        {
            _repo = repo;
            _mailService = mailService;
            _randomService = randomService;
        }

        public async Task<Result> Handle(SendMailCommand request, CancellationToken cancellationToken)
        {
            var acc = await _repo.accountRepo.GetByEmail(request.Email);
            if (acc == null)
                return Result.Failure(new Error("Error.Client", "No data exists"), "The email does not exist. Please double-check your email address.");

            acc.VerifyCode = await _randomService.RandomCode();
            acc.VerifyRefreshExpiry = DateTime.UtcNow.AddMinutes(1);
            _repo.accountRepo.Update(acc);

            var sendMail = new MailRequest
            {
                ToEmail = request.Email,
                Subject = "Verify Confirmation",
                Body = $"<h3>Code: {acc.VerifyCode}</h3>",
                Attachments = null
            };

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                await _mailService.SendMailAsync(sendMail);

                return Result.Success("Email verification is successful. Please check your email");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.SendMailCommand", "There is an error saving data!");
                return Result.Failure(error, "Email verification errors");
            }
        }
    }
}
