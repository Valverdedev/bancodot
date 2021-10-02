using bancodot.Domain;
using System;

namespace bancodot.Service.DTOs.AbstractionsDtos
{
    public abstract class EmployeeDto : PersonDto
    {     
              
        public DateTime AdmissionDate { get; set; }       
        public OccupationEnum Occupation { get; set; }
        public EmployeeStatusEnum Status { get; set; }
       
    }
}
