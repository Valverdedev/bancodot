using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;

namespace bancodot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientSelect _clientSelect;
        private readonly IClientCreat _clientCreat;
        public ClientController(IClientCreat clientCreat,
                                IClientSelect clientSelect)
        {
            _clientSelect = clientSelect;
            _clientCreat = clientCreat;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientCreatDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> addAgency(ClientCreatDto client)
        {            
           await _clientCreat.InsertAssync(client);

            return Ok(client);
        }

        [HttpGet("{cpf}")]
        public async Task<ClientSelectDto> SelectClient(string cpf)
        {
            return await _clientSelect.SelectByCpfAssync(cpf);
        }

    }

  
}
