using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using bancodot.Infra.Data.Context;
using bancodot.Infra.Data.Repository.abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MysqlContext _mySqlContext;
        private readonly IBaseRepository<Account> _baseRepository;

        public AccountRepository(IBaseRepository<Account> baseRepository, MysqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            _baseRepository = baseRepository;

        }
        public async Task InsertAssync(Account entity)
        {
          await _baseRepository.InsertAssync(entity);
        }

        public async Task<Account> SelectAssync(string AccountNumber)
        {           
            IQueryable<Account> query = _mySqlContext.Accounts
                .Include(a => a.Client)
                .Include(a => a.Agency)
                .Where(c => c.AccountNumber == AccountNumber);
            return await query.AsNoTracking().FirstOrDefaultAsync();
            
        }
    }
}

