
using Application.Common.Mapppings;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Entities.Roles;

namespace Application.DTOs.Requests
{
	public class AccountDTO : IMapForm<Account>
    {
        public string AccountId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string StatusAccount { get; set; }

        public List<ProcessByAssignees> ProcessByAssignees { get; set; }
    }
}

