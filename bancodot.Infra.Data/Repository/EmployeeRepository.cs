using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using bancodot.Infra.Data.Context;
using bancodot.Infra.Data.Repository.abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository
{
   public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly MysqlContext _mySqlContext;
        private readonly IBaseRepository<Employee> _baseRepository;
        public EmployeeRepository(IBaseRepository<Employee> baseRepository, MysqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            _baseRepository = baseRepository;
        }
        public async Task InsertAssync(Employee Entity)
        {
            await _baseRepository.InsertAssync(Entity);
        }

        public async Task<Employee> SelectAssync(string Enrrolment ) {

            return await _mySqlContext.Employee.Where(a => a.Enrollment == Enrrolment).Include(c => c.Agency.Name).Include(c => c.Agency.Code).FirstOrDefaultAsync();             
        }

        public Employee SelectLastAssync()
        {
            return  _mySqlContext.Employee.OrderByDescending(a => a.Enrollment).First();

        }
    }
}
