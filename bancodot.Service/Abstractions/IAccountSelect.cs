using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IAccountSelect
    {
        Task<AccountSelectDto> SelectAssync(string NumberAccount);
    }
}
