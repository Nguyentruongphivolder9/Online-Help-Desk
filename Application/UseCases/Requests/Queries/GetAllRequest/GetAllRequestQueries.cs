
using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.GetAllRequest
{
    public sealed record GetAllRequestQueries
        (string? SearchTerm, string? SortColumn, string? SortOrder,string? SortStatus ,int Page, int Limit)
        : IQuery<PagedList<RequestResponse>>;
}

