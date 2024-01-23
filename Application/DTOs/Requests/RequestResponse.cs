using System.Text.Json.Serialization;
using Application.Common.Mapppings;
using Domain.Entities.Requests;

namespace Application.DTOs.Requests
{
	public class RequestResponse : IMapForm<Request>
	{
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        public Guid RoomId { get; set; }
        public int RequestStatusId { get; set; }
        public string Description { get; set; }
        public string SeveralLevel { get; set; }
        public string? Reason { get; set; }
        public Boolean Enable { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        [JsonIgnore]
        public RequestStatus? RequestStatus { get; set; }
    }
}

