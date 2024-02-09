using Application.Common.Mapppings;
using Domain.Entities.Roles;

namespace Application.DTOs.Accounts
{
    public class RoleResponse : IMapForm<Role>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
