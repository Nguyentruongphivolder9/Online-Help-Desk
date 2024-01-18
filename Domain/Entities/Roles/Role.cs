using Domain.Entities.Accounts;
using SharedKernel;
using System.Text.Json.Serialization;

namespace Domain.Entities.Roles
{
    public class Role
    {
        public Guid Id { get; set; }
        public Guid RoleTypeId { get; set; }
        public string RoleName { get; set; }
        [JsonIgnore]
        public RoleType? RoleTypes { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
