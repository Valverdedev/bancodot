using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IEmployeeSelect
    {
        Task<EmployeeSelectDto> SelectAssync(string Enrollment);

    }
}
