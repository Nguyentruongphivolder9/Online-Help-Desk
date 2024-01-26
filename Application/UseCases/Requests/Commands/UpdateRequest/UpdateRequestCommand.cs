using Application.Common.Messaging;

namespace Application.UseCases.Requests.Commands.UpdateRequest
{
    public sealed record class UpdateRequestCommand(Guid Id ,int RequestStatusID ) : ICommand ;
}
