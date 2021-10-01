using bancodot.Domain.Entities.Abstracts;
using System.Collections.Generic;

namespace bancodot.Domain.Entities
{
    public class Client : PersonAbstract
    {
       public virtual ICollection<Account> Accounts { get; set; }
    }
}