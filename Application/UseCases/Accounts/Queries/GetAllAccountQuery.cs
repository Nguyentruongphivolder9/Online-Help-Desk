using Application.Common.Messaging;
using Application.DTOs;

namespace Application.UseCases.Accounts.Queries
{
    public sealed record GetAllAccountQuery(string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int PageSize) : IQuery<PagedList<AccountResponse>>;
}
