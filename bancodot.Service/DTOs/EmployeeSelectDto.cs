using bancodot.Domain;
using bancodot.Domain.Entities;
using bancodot.Service.DTOs.AbstractionsDtos;

namespace bancodot.Service.DTOs
{
    public class EmployeeSelectDto : EmployeeDto
    {
        public string AgencyNumber { get; set; }
        public string Agency { get; set; }
        public Address Address { get; set; }

        
    }
}
