using System;
using Application.Common.Messaging;
using Application.DTOs.Requests;

namespace Application.UseCases.Requests.Queries.GetListRequestByReStatusId
{
	public sealed record GetListRequestByReStatusIdQueries : IQuery<IEnumerable<RequestResponse>>
    {
        public int Id { get; set; }
    }
}

