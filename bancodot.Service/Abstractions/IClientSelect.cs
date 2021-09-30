using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
    public interface IClientSelect {
        Task<ClientSelectDto> SelectByCpfAssync(string Cpf);
       
    }
}
