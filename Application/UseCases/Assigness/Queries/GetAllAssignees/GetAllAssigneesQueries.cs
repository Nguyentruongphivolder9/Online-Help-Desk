
using Application.Common.Messaging;
using Application.DTOs.Requests;

namespace Application.UseCases.Assigness.Queries.GetAllAssignees
{
 public sealed record GetAllAssigneesQueries : IQuery<IEnumerable<ProcessByAssigneesDTO>>;
}

