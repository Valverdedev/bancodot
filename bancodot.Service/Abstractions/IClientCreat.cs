using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service.Abstractions
{
   public interface IClientCreat {
        Task InsertAssync(ClientCreatDto Entity);
    }
}
