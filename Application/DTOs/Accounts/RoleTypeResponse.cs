using Application.Common.Mapppings;
using Domain.Entities.Roles;

namespace Application.DTOs.Accounts
{
    public class RoleTypeResponse : IMapForm<RoleType>
    {
        public int Id { get; set; }
        public string RoleTypeName { get; set; }
    }
}
