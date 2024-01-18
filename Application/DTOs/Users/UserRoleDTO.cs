using Application.Common.Mapppings;
using Domain.Entities.Roles;
using System.Text.Json.Serialization;

namespace Application.DTOs.Users
{
    public class UserRoleDTO : IMapForm<Role>
    {
        public string RoleName { get; set; }
        [JsonIgnore]
        public UserDTO? User { get; set; }
    }
}
