using Application.Common.Messaging;
using Application.DTOs;
using Application.Services;
using Domain.Entities.Accounts;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Commands.Register
{
    public sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUnitOfWorkRepository _repo;
        private readonly IMailService _mailService;

        public RegisterCommandHandler(IUnitOfWorkRepository repo, IMailService mailService)
        {
            _repo = repo;
            _mailService = mailService;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            string password = "@abcOHD123";


            var userRegister = new Account
            {
                AccountId = request.AccountId,
                FullName = request.FullName,
                Email = request.Email,
                Password = "cdsfsdfs",
                //AvatarPhoto = request.AvatarPhoto,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                Birthday = request.Birthday,
                CreatedAt = DateTime.UtcNow,
                StatusAccount = StaticVariables.StatusAccountUser[0]
            };

            _repo.accountRepo.Add(userRegister);

            var sendMail = new MailRequest
            {
                ToEmail = request.Email,
                Subject = "Verify Confirmation",
                Body = $"<h3>Username: {request.AccountId}</h3>" +
                       "<br/>" +
                       $"<h4>Password: {password}</h4>",
                Attachments = null
            };

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                await _mailService.SendMailAsync(sendMail);

                return Result.Success("Register Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Error error = new("Error.RegisterCommandHandler", "There is an error saving data!");
                return Result.Failure(error, "Register failed!");
            }
        }
    }
}
