using Application.Common.Messaging;

namespace Application.UseCases.Requests.Commands.ProcessUpdateStatusRequest
{
    public sealed record ProcessUpdateStatusRequestCommand(Guid Id, int RequestStatusId, string? Reason) : ICommand;
}
