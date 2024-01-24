using Application.Common.Messaging;
using Application.DTOs;
using Application.Services;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Commands.SendMailVerifyCode
{
    public sealed class SendMailVerifyCodeCommandHandler : ICommandHandler<SendMailVerifyCodeCommand>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMailService _mailService;
        private readonly IRandomService _randomService;

        public SendMailVerifyCodeCommandHandler(IUnitOfWorkRepository repo, IMailService mailService, IRandomService randomService)
        {
            _repo = repo;
            _mailService = mailService;
            _randomService = randomService;
        }

        public async Task<Result> Handle(SendMailVerifyCodeCommand request, CancellationToken cancellationToken)
        {
            var acc = await _repo.accountRepo.GetByAccountId(request.AccountId);
            if (acc == null)
                return Result.Failure(new Error("Error.Client", "No data exists"), "The account code does not exist. Please double-check your account code.");

            acc.VerifyCode = await _randomService.RandomCode();
            acc.VerifyRefreshExpiry = DateTime.UtcNow.AddMinutes(1);
            _repo.accountRepo.Update(acc);

            var sendMail = new MailRequest
            {
                ToEmail = acc.Email,
                Subject = "Verify Confirmation",
                Body = $"<h3>Code: {acc.VerifyCode}</h3>",
                Attachments = null
            };

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                await _mailService.SendMailAsync(sendMail);

                return Result.Success("Account ID verification is successful. Please check your registered email.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.SendMailCommand", "There is an error saving data!");
                return Result.Failure(error, "Account code verification errors");
            }
        }
    }
}
