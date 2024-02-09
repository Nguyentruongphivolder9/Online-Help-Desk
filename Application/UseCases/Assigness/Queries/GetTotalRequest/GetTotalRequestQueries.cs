
using Application.Common.Messaging;
using Application.DTOs.Requests;
namespace Application.UseCases.Assigness.Queries.GetTotalRequest
{
    public sealed record GetTotalRequestQueries : IQuery<int>
    {
        public string AccountId { get; set; }
    }
}

