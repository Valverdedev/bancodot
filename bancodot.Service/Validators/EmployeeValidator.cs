using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.DTOs;
using FluentValidation;
using System;

namespace bancodot.Service.Validators
{
   public class EmployeeValidator : AbstractValidator<EmployeeCreatDto>
    {
        private IEmployeeRepository _employeeRepository;
        public ValidateCpf _validateCpf;
        public EmployeeValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            _validateCpf = new ValidateCpf();

            RuleFor(c => c.BirthDate)
                .NotNull().WithMessage("Informe a Data de Nascimento")
                .Must(EmployeeAge).WithMessage("Funcionário deve ser maior de 18 anos");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Favor Inserir um CPF.")
                .NotNull().WithMessage("Favor Inserir um CPF.")
                .Must(ValidateCpf).WithMessage("Cpf Inválido")
                .Must(CpfExist).WithMessage("Cpf já cadastrado em nossa base da dados");
        }

        private bool CpfExist(string arg)
        {
          var res = _employeeRepository.SelectByCpfAssync(arg);
            if (res.Result == null)
            {
                return true;
            }
            return false;
        }

        private bool ValidateCpf(string Cpf)
        {
            return _validateCpf.Validate(Cpf);
        }

        private bool EmployeeAge(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now.AddYears(-18);
        }
    }
}
