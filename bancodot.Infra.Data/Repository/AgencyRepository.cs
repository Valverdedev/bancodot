using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using bancodot.Infra.Data.Context;
using bancodot.Infra.Data.Repository.abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository
{
    public class AgencyRepository : IAgencyRepository
    {
        protected readonly MysqlContext _mySqlContext;
        private readonly IBaseRepository<Agency> _baseRepository;
        public AgencyRepository(IBaseRepository<Agency> baseRepository, MysqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
            _baseRepository = baseRepository;
        }

        public async Task InsertAssync(Agency entity)
        {
          await  _baseRepository.InsertAssync(entity);
        }

        public async Task<Agency> SelectAssync(string Code)
        {
           
            return await _mySqlContext.Agency.Where(a => a.Code == Code).Include(a => a.Address).FirstOrDefaultAsync();
        }

        public Agency SelectById(int id)
        {
            return _baseRepository.Select(id);
        }
    }
}
