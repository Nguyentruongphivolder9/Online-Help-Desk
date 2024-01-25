using Application.Common.Messaging;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.SortingRequest
{

    public sealed record SortingRequestQueries : IQuery<IEnumerable<RequestResponse>>;
}

