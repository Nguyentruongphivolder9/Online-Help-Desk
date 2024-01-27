﻿using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Accounts;

namespace Application.UseCases.Accounts.Queries.GetAllAccount
{
    public sealed record GetAllAccountQuery(string? SearchTerm, string? SortColumn, string? SortOrder, int Page, int Limit) : IQuery<PagedList<AccountResponse>>;
}
