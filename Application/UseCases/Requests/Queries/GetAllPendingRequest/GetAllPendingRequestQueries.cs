using System;
using Application.Common.Messaging;
using Application.DTOs;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.GetAllPendingRequest
{
	public sealed record GetAllPendingRequestQueries
        (string? SearchTerm, string? SortColumn, string? SortOrder,
        string? SortStatus, int Page, int Limit)
        : IQuery<PagedList<RequestResponse>>;
}

