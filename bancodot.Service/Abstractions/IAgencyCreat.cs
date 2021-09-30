using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IAgencyCreat
    {
        Task InsertAssync(AgencyCreatDto Entity);

    }
}
