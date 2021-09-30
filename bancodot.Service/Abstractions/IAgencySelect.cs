using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IAgencySelect
    {
        Task<AgencySelectDto> SelectAssync(string CodeAgencia);
    }
}
