using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;

namespace bancodot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyCreat _agencyCreat;
        private readonly IAgencySelect _agencySelect;
       
        public AgencyController(IAgencyCreat agencyCreat,
                                IAgencySelect agencySelect)
        {
            _agencyCreat = agencyCreat;
            _agencySelect = agencySelect;
          
        }
        [HttpPost]
        [ProducesResponseType(typeof(AgencyCreatDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> addAgency(AgencyCreatDto agency)
        {
            await _agencyCreat.InsertAssync(agency);
            
            return Ok(agency);
        }

        [HttpGet("{CodeAgencia}")]
        public async Task<AgencySelectDto> SelectClient(string CodeAgencia)
        {
            return await _agencySelect.SelectAssync(CodeAgencia);
        }
    }


}
