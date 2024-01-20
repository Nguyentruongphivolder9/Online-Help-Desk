using Application.Common.Messaging;
using Application.DTOs;

namespace Application.UseCases.Accounts.Commands.Login
{
    //LoginCommand is declared as a sealed (non-inheritable) record.
    //In C#, records are a concise way to declare immutable types with value-based equality

    //It implements the ICommand<LoginResponse> interface, indicating that this class represents
    //a command that produces a result of type LoginResponse upon execution.
    public sealed record LoginCommand(string Email, string Password) : ICommand<LoginResponse>;
}
