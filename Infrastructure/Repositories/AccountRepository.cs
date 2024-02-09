﻿using Domain.Entities.Accounts;
using Domain.Entities.Requests;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public sealed class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
       public AccountRepository(OHDDbContext dbContext) 
            : base(dbContext) { }

        public async Task<bool> CheckRegisterAccount(string accountId)
        {
            var acc = await _dbContext.Set<Account>()
                .SingleOrDefaultAsync(u => u.AccountId == accountId);
            if (acc != null)
                return false;
            return true;
        }

        public async Task<DataResponse<Account>> GetAllAccountSSFP(
            string? searchTerm, 
            string? sortColumn, 
            string? sortOrder,
            string? roleType,
            int page,
            int pageSize,
            CancellationToken cancellationToken)
        {
            IQueryable<Account> accountQuery = _dbContext.Set<Account>()
                .Include(a => a.Role)
                .ThenInclude(r => r!.RoleTypes);

            if(!string.IsNullOrEmpty(searchTerm) )
            {
                accountQuery = accountQuery.Where(a => 
                a.AccountId.Contains(searchTerm) || 
                a.Email.Contains(searchTerm) || 
                a.FullName.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(roleType))
            {
                accountQuery = accountQuery.Where(a =>
                a.Role!.RoleTypes!.RoleTypeName == roleType);
            }

            Expression<Func<Account, object>> keySelector = sortColumn?.ToLower() switch
            {
                "accountid" => account => account.AccountId,
                "fullname" => account => account.FullName,
                "birthday" => account => account.Birthday,
                "statusaccount" => account => account.StatusAccount,
                "rolename" => account => account.Role!.RoleName,
                _ => account => account.CreatedAt,

            };

            if(sortOrder?.ToLower() == "desc")
            {
                accountQuery = accountQuery.OrderByDescending(keySelector);
            } else
            {
                accountQuery = accountQuery.OrderBy(keySelector);
            }

            var totalCount = await accountQuery.CountAsync();

            var accounts = await accountQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new DataResponse<Account>
            {
                Items = accounts,
                TotalCount = totalCount,
            };
        }

        public async Task<Account?> GetByAccountId(string accountId)
        {
            var user = await _dbContext.Set<Account>()
                .Include(a => a.Role)
                .ThenInclude(c => c.RoleTypes)
                .Include(r => r.Requests)
                .Include(rem => rem.Remarks)
                .SingleOrDefaultAsync(u => u.AccountId == accountId);
            return user;
        }

        public async Task<Account?> GetByEmail(string email)
        {
            var user = await _dbContext.Set<Account>().SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<Account?> GetByPhoneNumber(string phone)
        {
            var user = await _dbContext.Set<Account>().FirstOrDefaultAsync(u => u.PhoneNumber == phone);
            return user;
        }

        public async Task<IEnumerable<Account?>> GetListAssignees()
        {
            var listAssignees = await _dbContext.Set<Account>()
                .Where(u => u.RoleId == 4 && u.StatusAccount == "Active")
                .ToListAsync();

            return listAssignees;
        }


        public async Task<Account?> GetStaySignIn(string accountId, string refreshToken)
        {
            var user = await _dbContext.Set<Account>()
                .Include(a => a.Role)
                .ThenInclude(c => c.RoleTypes)
                .SingleOrDefaultAsync(u =>
                    u.AccountId == accountId &&
                    u.RefreshToken == refreshToken
                );
            return user;
        }
    }
}
