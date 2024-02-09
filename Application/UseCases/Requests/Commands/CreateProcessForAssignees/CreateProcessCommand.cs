using Application.Common.Messaging;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Commands.CreateProcessForAssignees
{
    public record class CreateProcessCommand (Guid RequestId , string AccountId ,int RequestStatusId) : ICommand;
}

