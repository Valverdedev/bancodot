using System;

namespace bancodot.Domain.Entities
{
    public class Account : BaseEntity
    {
       public string AccountNumber { get; set; }
       public int AgencyId { get; set; }
       public Agency Agency { get; set; }
       public int ManagerId { get; set; }
       public Employee Manager { get; set; }
       public AccountTypeEnum AccountType { get; set; }
       public AccountStatusEnum AccountStatus { get; set; }
       public DateTime OpeningDate { get; set; }
       public int ClientId { get; set; }
       public virtual  Client Client { get; set; }
       public double Balance { get; set; }
       public double SpecialLimit { get; set; }

    }
}
