using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository.abstractions
{
    public interface IAccountRepository 
    {
        Task InsertAssync(Account entity);
        Task<Account> SelectAssync(string Code);
    }
}
