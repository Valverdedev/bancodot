using bancodot.Domain;
using bancodot.Service.DTOs;
using FluentValidation;
using System;

namespace bancodot.Service.Validators
{
    public class AccountValidator : AbstractValidator<AccountCreatDto>
    {
        public AccountValidator()
        {
            RuleFor(c => c.ClientId)
                .NotNull().WithMessage("Selecione um cliente");
               

            RuleFor(c => c.AgencyId)
               .NotNull().WithMessage("Selecione um Agência");

            RuleFor(c => c.ManagerId)
               .NotNull().WithMessage("Selecione um cliente");

                          

        }

            
                
      }
}
