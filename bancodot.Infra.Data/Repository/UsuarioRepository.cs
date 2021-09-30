using bancodot.Domain.Entities;
using bancodot.Infra.Data.Context;
using bancodot.Infra.Data.Repository.abstractions;

namespace bancodot.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<User>, IUsuarioRepository
    {
        public UsuarioRepository(MysqlContext mySqlContext) : base(mySqlContext)
        {
        }
    }
}
