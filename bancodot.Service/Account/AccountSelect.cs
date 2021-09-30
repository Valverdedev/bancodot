using AutoMapper;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class AccountSelect : IAccountSelect
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountSelect(IAccountRepository accountRepository, IMapper mapper)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<AccountSelectDto> SelectAssync(string NumberAccount)
        {
           var Account = await _accountRepository.SelectAssync(NumberAccount);
           
            return _mapper.Map<AccountSelectDto>(Account);
        }
    }
}
