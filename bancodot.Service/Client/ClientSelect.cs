using AutoMapper;
using bancodot.Domain.Entities;
using bancodot.Domain.Interfaces;
using bancodot.Infra.Data.Repository;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class ClientSelect : Client, IClientSelect
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientSelect(IClientRepository clientRepository, IMapper mapper)
        {
           
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async Task<ClientSelectDto> SelectByCpfAssync(string Cpf)
        {
            var client = await _clientRepository.SelectByCpfAssync(Cpf);
     
            return _mapper.Map<ClientSelectDto>(client);
        }

      
    }
}
