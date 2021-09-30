using bancodot.Infra.Data.Repository.abstractions;
using System;

namespace bancodot.Service.Services
{
    public class GenereteEnrolmentEmployee
    {
        private IEmployeeRepository _employeeRepository;
        public GenereteEnrolmentEmployee(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string GetLastEnrolmentAsync()
        {
            int enrolment = 1000;
            try
            {
                var employer = _employeeRepository.SelectLastAssync();
                if (employer != null)
                {
                    enrolment = Int32.Parse(employer.Enrollment);
                }
            }
            catch (Exception)
            {

                throw;
            }
          
            
           
            enrolment++;
            return enrolment.ToString();
        }

    }
}
