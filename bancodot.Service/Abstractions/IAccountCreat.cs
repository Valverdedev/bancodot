using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IAccountCreat
    {
     Task InsertAssync(AccountCreatDto Entity);
    }
}
