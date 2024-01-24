using Application.Common.Mapppings;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;

namespace Application.DTOs.Requests
{
	public class RequestResponse : IMapForm<Request>
	{
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string SeveralLevel { get; set; }
        public string? Reason { get; set; }
        public Boolean Enable { get; set; }
        public DateTime CreatedAt { get; set; }

        public RequestStatusDTO RequestStatus { get; set; }
        public AccountDTO Account { get; set; }
    }
}

