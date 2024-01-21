using Application.Common.Messaging;

namespace Application.UseCases.Accounts.Commands.Verify
{
    public sealed record VerifyCommand(string VerifyCode) : ICommand;
}
