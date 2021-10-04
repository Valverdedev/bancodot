using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.DTOs;
using FluentValidation;
using System;

namespace bancodot.Service.Validators
{
    public class AgencyValidator : AbstractValidator<AgencyCreatDto>
    {
        private IAgencyRepository _agencyRepository;

        public AgencyValidator(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;

            CascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Code)
                .NotNull().WithMessage("O código da Agência deve ser inserido")
                .Length(4).WithMessage("O código da Agência deve conter 4 dígitos")
                .Must(checkAgencyExist).WithMessage("o código informado já está em uso por outra agência");
        }

        private bool checkAgencyExist(string arg)
        {
            var agency = _agencyRepository.SelectByCodeAssync(arg);
              if (agency.Result == null)
            {
                return true;
            }
            else { return false; }
        }
    }
}
