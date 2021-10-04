using AutoMapper;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class AgencySelect : Agency, IAgencySelect
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public AgencySelect(IAgencyRepository agencyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }
        public async Task<AgencySelectDto> SelectAssync(string CodeAgencia)
        {
           var agency = await _agencyRepository.SelectByCodeAssync(CodeAgencia);
           
            return _mapper.Map<AgencySelectDto>(agency);
        }
    }
}
