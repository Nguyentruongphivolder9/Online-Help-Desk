using Application.Common.Messaging;
using Application.DTOs;

namespace Application.UseCases.Accounts.Commands.Login
{
    public sealed record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;
}
