using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IEmployeeCreat
    {
        Task InsertAssync(EmployeeCreatDto Entity);
    }
}
