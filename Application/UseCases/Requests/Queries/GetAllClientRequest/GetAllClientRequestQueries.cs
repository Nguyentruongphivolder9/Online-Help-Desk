using Application.Common.Messaging;
using Application.DTOs.Requests;
using Application.DTOs;

namespace Application.UseCases.Requests.Queries.GetAllClientRequest
{
    public sealed record GetAllClienRequestQueries(string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int Limit) :
        IQuery<PagedList<RequestResponse>>;
}
