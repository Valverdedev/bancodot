using System.Threading.Tasks;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Domain.Entities;
using bancodot.Service.DTOs;
using AutoMapper;

namespace bancodot.Service
{
    public class ClientCreat : Client, IClientCreat
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        public ClientCreat(IClientRepository clientRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
              
        public async Task InsertAssync(ClientCreatDto Entity)
        {
            var client = _mapper.Map<Client>(Entity);
        await  _clientRepository.InsertAssync(client);

        }
      
    }

    
}
