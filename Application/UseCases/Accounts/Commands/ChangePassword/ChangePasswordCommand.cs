using Application.Common.Messaging;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(string AccountId, string NewPassword, string ConfirmPassword) : ICommand;
}
