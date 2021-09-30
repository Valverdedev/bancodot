using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using bancodot.Infra.Data.Context;
using bancodot.Infra.Data.Repository.abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        protected readonly MysqlContext _mySqlContext;
        private readonly IBaseRepository<Client> _baseRepository;
        public ClientRepository(IBaseRepository<Client> baseRepository, MysqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            _baseRepository = baseRepository;
        }
        public async Task Insert(Client Entity)
        {
            throw new System.NotImplementedException();
           
        }

        public async Task InsertAssync(Client Entity)
        {
           await _baseRepository.InsertAssync(Entity);
         
        }
 
        public IList<Client> Select()
        {
           return _baseRepository.Select();
        }

      
        public async Task<Client> SelectByCpfAssync(string Cpf)
        {
            return await _mySqlContext.Client.Where(c => c.Cpf == Cpf).Include(e => e.Account).Include(a => a.Address).FirstOrDefaultAsync();

         }
        public Client SelectByIdAssync(int id)
        {
            return _baseRepository.Select(id);

        }

        public void Update(Client Entity)
        {
            _baseRepository.Update(Entity);
        }

       
    }
}
