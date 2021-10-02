using bancodot.Domain;

namespace bancodot.Service.DTOs.AbstractionsDtos
{
    public abstract class AccountDto
    {
        public int AgencyId { get; set; }
        public int ManagerId { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public int ClientId { get; set; }
        public double Balance { get; set; }
        public double SpecialLimit { get; set; }
    }
}
