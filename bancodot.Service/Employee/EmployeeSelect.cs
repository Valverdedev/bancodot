using AutoMapper;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class EmployeeSelect : Employee, IEmployeeSelect
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeSelect(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }
  
      public async  Task<EmployeeSelectDto>SelectAssync(string Enrollment)
        {
            var employee = await _employeeRepository.SelectAssync(Enrollment);
          
            return _mapper.Map<EmployeeSelectDto>(employee);
        }
    }
}
