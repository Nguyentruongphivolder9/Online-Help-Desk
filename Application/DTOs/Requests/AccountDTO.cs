using System;
using Application.Common.Mapppings;
using Domain.Entities.Accounts;
using Domain.Entities.Requests;

namespace Application.DTOs.Requests
{
	public class AccountDTO : IMapForm<Account>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}

