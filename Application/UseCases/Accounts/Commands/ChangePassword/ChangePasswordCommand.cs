using Application.Common.Messaging;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(string Email, string Newpassword, string ConfirmPassword) : ICommand;
}
