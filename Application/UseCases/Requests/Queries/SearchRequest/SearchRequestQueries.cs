using System;
using Application.Common.Messaging;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.SearchRequest
{
    public sealed record SearchRequestQueries : IQuery<IEnumerable<RequestResponse>>
    {
        public string Search { get; set; }
    }
}


