using bancodot.Domain.Entities;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository.abstractions
{
  public  interface IEmployeeRepository
    {
      Task InsertAssync(Employee Entity);
      Task<Employee> SelectAssync(string Code);
      Employee SelectLastAssync();
    }
}
