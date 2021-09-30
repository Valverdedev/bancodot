using bancodot.Domain.Entities;
using bancodot.Infra.Data.Repository.abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bancodot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UserController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        [HttpPost]
        public async Task<IActionResult> addUsuario(User user)
        {
       
                     
            _usuarioRepository.Insert(user);

            return Ok(user);

        }

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            _usuarioRepository.Delete(id);
            return NoContent();
        }
    }
}
