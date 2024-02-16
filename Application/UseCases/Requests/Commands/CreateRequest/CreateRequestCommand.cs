using Application.Common.Messaging;

namespace Application.UseCases.Requests.Commands.CreateRequest
{
    public record class CreateRequestCommand(string AccountId, string RoomId, int RequestStatusId,
        string Description, string SeveralLevel, DateTime? Date) : ICommand;
}
