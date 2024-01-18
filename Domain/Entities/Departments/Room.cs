using Domain.Entities.Requests;
using System.Text.Json.Serialization;

namespace Domain.Entities.Departments
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomStatus { get; set; }

        public List<Request>? Requests { get; set; }
        [JsonIgnore]
        public Department? Departments { get; set; }
    }
}
