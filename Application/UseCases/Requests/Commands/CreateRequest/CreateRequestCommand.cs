using Application.Common.Messaging;

namespace Application.UseCases.Requests.Commands.CreateRequest
{
    public record class CreateRequestCommand(string AccountId, Guid RoomId, int RequestStatusId,  string Description, string SeveralLevel) : ICommand;
}
