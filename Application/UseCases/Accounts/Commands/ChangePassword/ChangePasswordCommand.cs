using Application.Common.Messaging;

namespace Application.UseCases.Accounts.Commands.ChangePassword
{
    public sealed record ChangePasswordCommand(string newpassword, string confirmPassword) : ICommand;
}
