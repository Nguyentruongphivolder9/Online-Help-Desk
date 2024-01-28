
using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.GetAllRequest
{
    public sealed record GetAllRequestQueries
        (string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int PageSize)
        : IQuery<PagedList<RequestResponse>>;
}

