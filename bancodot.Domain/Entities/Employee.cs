using bancodot.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;

namespace bancodot.Domain.Entities
{
    public class Employee : PersonAbstract
    {
        public string Enrollment { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DismissalDate  { get; set; }
        public OccupationEnum Occupation { get; set; }
        public float Salary { get; set; }
        public EmployeeStatusEnum Status { get; set; }
        public virtual Agency? Agency { get; set; }
        public int? AgencyId { get; set; }
    }
}