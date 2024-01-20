using Application.Common.Messaging;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Accounts.Commands.Register
{
    public sealed record RegisterCommand(
        string AccountId,
        int RoleId,
        string FullName,
        string Email,
        //IFormFile AvatarPhoto,
        string Address,
        string PhoneNumber,
        string Gender,
        string Birthday) : ICommand;
}
