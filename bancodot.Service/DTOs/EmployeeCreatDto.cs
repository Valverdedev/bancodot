using bancodot.Domain;
using bancodot.Service.DTOs.AbstractionsDtos;
using System;

namespace bancodot.Service.DTOs
{
    public class EmployeeCreatDto : EmployeeDto
    {
        public DateTime BirtDate { get; set; }
        public GenreEnum Genre { get; set; }
        public float Salary { get; set; }
        public int? AgencyId { get; set; }
        public virtual AddressDto Address { get; set; }

    }
}
