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
        private readonly IBCryptService _bCryptService;

        public RegisterCommandHandler(IUnitOfWorkRepository repo, IMailService mailService, IBCryptService bCryptService)
        {
            _repo = repo;
            _mailService = mailService;
            _bCryptService = bCryptService;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var checkAccountId = await _repo.accountRepo.GetByAccountId(request.AccountId);
            if (checkAccountId != null)
                return Result.Failure(new Error("Error.Client", "Data duplication"), "AccountId already exists");

            var checkEmail = await _repo.accountRepo.GetByEmail(request.Email);
            if (checkEmail != null)
                return Result.Failure(new Error("Error.Client", "Data duplication"), "Email already exists");

            var checkPhone = await _repo.accountRepo.GetByPhoneNumber(request.PhoneNumber);
            if (checkPhone != null)
                return Result.Failure(new Error("Error.Client", "Data duplication"), "Phone number already exists");

            string password = "@abcOHD123";
            string hashPassword = _bCryptService.EncodeString(password);

            var userRegister = new Account
            {
                AccountId = request.AccountId,
                RoleId = request.RoleId,
                FullName = request.FullName,
                Email = request.Email,
                Password = hashPassword,
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
                Body = "<br/>" + 
                       $"<h3>Username: {request.AccountId}</h3>" +
                       "<br/>" +
                       $"<h4>Password: {password}</h4>" +
                       $"<br/>",
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
