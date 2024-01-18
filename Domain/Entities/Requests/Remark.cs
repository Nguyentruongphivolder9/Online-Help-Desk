using Domain.Entities.Accounts;
using System.Text.Json.Serialization;

namespace Domain.Entities.Requests
{
    public class Remark
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public string AccountId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }

        [JsonIgnore]
        public Account? Account { get; set; }
        [JsonIgnore]
        public Request? Request { get; set; }
    }
}
