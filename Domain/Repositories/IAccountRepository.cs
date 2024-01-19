﻿using Domain.Entities.Accounts;

namespace Domain.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account> 
    { 
        Task<Account?> GetByEmail(string email);
    }
}