using AutoMapper;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Repository.abstractions;
using bancodot.Service.Abstractions;
using bancodot.Service.DTOs;
using System.Threading.Tasks;

namespace bancodot.Service
{
    public class AgencyCreat : IAgencyCreat
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        public AgencyCreat(IAgencyRepository agencyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }
        public async Task InsertAssync(AgencyCreatDto Entity)
        {
            var agency = _mapper.Map<Agency>(Entity);
            
            await _agencyRepository.InsertAssync(agency);
        }
    }
}
