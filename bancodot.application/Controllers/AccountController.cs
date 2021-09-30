using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bancodot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountSelect _accountSelect;
        private readonly IAccountCreat _accountCreat;

        public AccountController(IAccountCreat accountCreat, IAccountSelect accountSelect )
        {
            _accountSelect = accountSelect;
            _accountCreat = accountCreat;
        }
        [HttpPost]
        [ProducesResponseType(typeof(AccountCreatDto), StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> addAgency(AccountCreatDto account)
        {
            await _accountCreat.InsertAssync(account);

            return Ok(account);
        }

        [HttpGet("{NumberAccount}")]
        public async Task<AccountSelectDto> SelectClient(string NumberAccount)
        {
            return await _accountSelect.SelectAssync(NumberAccount);
        }
    }
}
