using Application.Common.Mapppings;
using Domain.Entities.Roles;

namespace Application.DTOs.Accounts
{
    public class RoleDTO : IMapForm<Role>
    {
        public string RoleName { get; set; }
        public RoleTypeDTO RoleTypes { get; set; }
    }
}
