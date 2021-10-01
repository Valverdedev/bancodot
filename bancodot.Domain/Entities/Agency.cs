
using System.Collections.Generic;

namespace bancodot.Domain.Entities
{
    public class Agency : BaseEntity
    {
        public Agency()
        {
            Accounts = new HashSet<Account>();
            Employers = new HashSet<Employee>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Employee> Employers { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
