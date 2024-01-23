using Application.Common.Messaging;

namespace Application.UseCases.Requests.Commands.UpdateRequest
{
    public record class UpdateRequestCommand(string AccountId, Guid RoomId, int RequestStatusId, string Description, string SeveralLevel, string Reason) : ICommand
    {
        public Guid Id { get; set; }
    };

}
