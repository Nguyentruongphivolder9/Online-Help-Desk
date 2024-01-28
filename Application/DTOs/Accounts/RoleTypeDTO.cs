using Application.Common.Mapppings;
using Domain.Entities.Roles;

namespace Application.DTOs.Accounts
{
    public class RoleTypeDTO : IMapForm<RoleType>
    {
        public string RoleTypeName { get; set; }
    }
}
