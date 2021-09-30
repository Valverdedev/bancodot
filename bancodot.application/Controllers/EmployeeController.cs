using bancodot.Domain.Entities;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bancodot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeSelect _employeeSelect;
        private readonly IEmployeeCreat _employeeCreat;
        public EmployeeController(IEmployeeCreat employeeCreat, IEmployeeSelect employeeSelect)
        {
            _employeeSelect = employeeSelect;
            _employeeCreat = employeeCreat;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeCreatDto), StatusCodes.Status201Created)]
      
        public async Task<IActionResult> addAgency(EmployeeCreatDto employee)
        {

            await _employeeCreat.InsertAssync(employee);

            return Ok(employee);

        }

        [HttpGet("{Enrollment}")]
        public async Task<EmployeeSelectDto> SelectClient(string Enrollment)
        {
            return await _employeeSelect.SelectAssync(Enrollment);
        }
    }
}
