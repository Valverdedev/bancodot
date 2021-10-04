using bancodot.Domain.Entities;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository.abstractions
{
  public  interface IEmployeeRepository
    {
      Task InsertAssync(Employee Entity);
      Task<Employee> SelectByEnrolmentAssync(string Code);
      Task<Employee> SelectByCpfAssync(string Cpf);
      Employee SelectLastAssync();
    }
}
