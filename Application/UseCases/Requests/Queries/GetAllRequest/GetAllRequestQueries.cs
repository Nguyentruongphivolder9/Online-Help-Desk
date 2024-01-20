using Application.Common.Messaging;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.GetAllRequest
{
    public sealed record GetAllRequestQueries : IQuery<IEnumerable<RequestResponse>>;
}

