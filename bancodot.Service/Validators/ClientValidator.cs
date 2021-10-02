using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.DTOs;
using FluentValidation;
using System;


namespace bancodot.Service.Validators
{
    public class ClientValidator : AbstractValidator<ClientCreatDto>
    {
       public readonly IClientRepository _clientRepository;
        public ValidateCpf _validateCpf;
        public ClientValidator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _validateCpf = new ValidateCpf();

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Favor Inserir um CPF.")
                .NotNull().WithMessage("Favor Inserir um CPF.")
                .Must(ValidateCpf).WithMessage("Cpf Inválido")
                .Must(CpfExist).WithMessage("Cpf já cadastrado em nossa base da dados");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Favor Inserir um Nome.")
                .NotNull().WithMessage("Favor Inserir um Nome.");

            RuleFor(c => c.BirtDate)
               .NotEmpty().WithMessage("Favor entrar com data válida.")
               .NotNull().WithMessage("Favor entrar com data válida.")
               .Must(ClientAge).WithMessage("O Cliente deve ser maior de idade");            
        }

        private  bool ClientAge(DateTime dataNascimento)
        {           
            return dataNascimento <= DateTime.Now.AddYears(-18);
        }
        private  bool ValidateCpf(string Cpf)
        {          
            return _validateCpf.Validate(Cpf);
        }
        
        private bool CpfExist(string Cpf)
        {                     
          var res =  _clientRepository.SelectByCpfAssync(Cpf);
          if(res.Result == null)
            {
                return true;
            }
                return false;           
        }
       
    }
}

