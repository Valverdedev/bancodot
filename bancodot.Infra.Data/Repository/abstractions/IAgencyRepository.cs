using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancodot.Infra.Data.Repository.abstractions
{
   public interface IAgencyRepository
    {
        Task InsertAssync(Agency entity);
        Task<Agency> SelectAssync(string Code);
        Agency SelectById(int id);
    }
}
