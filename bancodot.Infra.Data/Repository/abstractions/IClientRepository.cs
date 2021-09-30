using bancodot.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository.abstractions
{
  public  interface IClientRepository 
    {
       Task InsertAssync(Client Entity);

        void Update(Client Entity);

        IList<Client> Select();
        Client SelectByIdAssync(int id);
        Task<Client> SelectByCpfAssync(string Cpf);
    }
}
