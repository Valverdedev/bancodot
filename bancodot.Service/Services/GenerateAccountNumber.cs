using bancodot.Domain;

namespace bancodot.Service.Services
{
    public class GenerateAccountNumber
    {
        public GenerateAccountNumber()
        {

        }

        public string NumberCreat(string AgencyCode, string Cpf, AccountTypeEnum AccountType)
        {
            long Product = 0;
           long result = long.Parse(AgencyCode) * long.Parse(Cpf);

            if (AccountType == AccountTypeEnum.Corrente) Product = result * 2;
            if (AccountType == AccountTypeEnum.Especial) Product = result * 3;
            if (AccountType == AccountTypeEnum.Poupança) Product = result * 4;
            if (AccountType == AccountTypeEnum.Univeristaria) Product = result * 5;

            string NumberAccount = Product.ToString().Substring(0, 6);
            return NumberAccount;  
        }
    }
}
