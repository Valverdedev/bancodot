using bancodot.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bancodot.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task InsertAssync(TEntity obj);
        
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        IList<TEntity> Select();

        TEntity Select(int id);
    }
    
}

