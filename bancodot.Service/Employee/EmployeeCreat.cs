using AutoMapper;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using bancodot.Service.Services;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class EmployeeCreat : Employee, IEmployeeCreat
    {
        private readonly GenereteEnrolmentEmployee _genereteEnrolmentEmployee;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeCreat(IEmployeeRepository employeeRepsitory, IMapper mapper, GenereteEnrolmentEmployee genereteEnrolmentEmployee )
        {
            _genereteEnrolmentEmployee = genereteEnrolmentEmployee;
            _mapper = mapper;
            _employeeRepository = employeeRepsitory;

        }
        public async Task InsertAssync(EmployeeCreatDto Entity)
        {
            var employee = _mapper.Map<Employee>(Entity);

            employee.Enrollment = _genereteEnrolmentEmployee.GetLastEnrolmentAsync();
           await _employeeRepository.InsertAssync(employee);
        }
    }
}
