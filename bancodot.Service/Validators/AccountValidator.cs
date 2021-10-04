using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.DTOs;
using FluentValidation;

namespace bancodot.Service.Validators
{
    public class AccountValidator : AbstractValidator<AccountCreatDto>
    {
        private IClientRepository _clientrepository;
        private IAccountRepository _accountRepository;

        public AccountValidator(IAccountRepository accountRepository,
                               IClientRepository clientRepository)
        {
            _clientrepository = clientRepository;
        
            _accountRepository = accountRepository;
            CascadeMode = CascadeMode.Stop;

           
            RuleFor(c => c.ClientId)
                .NotNull().WithMessage("Selecione um cliente")
                .Must(CheckId).WithMessage("Cliente Inexistente");

            RuleFor(c => c.AgencyId)
                .NotNull().WithMessage("Selecione um Agência");

            RuleFor(c => c.ManagerId)
               .NotNull().WithMessage("Selecione um gestor da conta");

            RuleFor(c => c)
               .NotNull().WithMessage("Selecione um tipo de conta")
               .Must(CheckClientAccountType).WithMessage(c => $"Cliente já possui uma conta {c.AccountType }");
        }

      
        private bool CheckId(int arg)
        {
            var client = _clientrepository.SelectById(arg);
            if (client == null)
            {
                return false;
            }
            else { return true; }

        }

        private bool CheckClientAccountType(AccountCreatDto arg)
        {
            bool res =true;
            var client = _clientrepository.SelectById(arg.ClientId);
            
            foreach (var item in client.Accounts)
            {
                if (item.AccountType == arg.AccountType)
                {
                    res = false;
                }

            }
                      
            return res;
        }
             
    }
}
