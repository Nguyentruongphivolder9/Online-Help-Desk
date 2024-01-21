using Application.Common.Messaging;
using Domain.Repositories;
using SharedKernel;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    public sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUnitOfWorkRepository _repo;

        public ChangePasswordCommandHandler(IUnitOfWorkRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var acc = await _repo.accountRepo.GetByEmail(request.Email);
            if (acc == null)
                return Result.Failure(new Error("Error.Client", "No data exists"), "The email does not exist. Please double-check your email address.");

            if (!acc.Enable)
            {
                acc.Enable = true;
            }

            acc.Password = request.Newpassword;
            acc.UpdatedAt = DateTime.UtcNow;
            _repo.accountRepo.Update(acc);

            try
            {
                await _repo.SaveChangesAsync(cancellationToken);
                return Result.Success("Change password successfully.");
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
