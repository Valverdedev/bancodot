using AutoMapper;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using bancodot.Service.Services;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class AccountCreat : IAccountCreat
    {
        private readonly IAccountRepository _accountRepository;
        private readonly GenerateAccountNumber _generateNumberAccount;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public AccountCreat(IAccountRepository accountRepository,
                           IMapper mapper, 
                           IClientRepository clientRepository, 
                           IAgencyRepository agencyRepository,
                            GenerateAccountNumber generateNumber)
        {
            _generateNumberAccount = generateNumber;
            _agencyRepository = agencyRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;

        }
            
        public async Task InsertAssync(AccountCreatDto Entity)
        {
           var client =  _clientRepository.SelectByIdAssync(Entity.ClientId);
           var agency = _agencyRepository.SelectById(Entity.AgencyId);         

            var account = _mapper.Map<Account>(Entity);
            account.AccountNumber = _generateNumberAccount.NumberCreat(agency.Code, client.Cpf, account.AccountType);
        await  _accountRepository.InsertAssync(account);
        }
    }
}
