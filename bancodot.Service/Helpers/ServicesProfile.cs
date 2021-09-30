using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using bancodot.Domain;
using bancodot.Domain.Entities;
using bancodot.Service.DTOs;
using System.Linq;

namespace bancodot.Service.Helpers
{
    class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Agency, AgencyCreatDto>().ReverseMap();
            CreateMap<Agency, AgencySelectDto>().ReverseMap();
            CreateMap<Client, ClientCreatDto>().ReverseMap();

            CreateMap<Client, ClientSelectDto>()
            .ForMember(a => a.Accounts, opts => opts.MapFrom(a => a.Account.Select
            (c => new { c.AccountNumber, c.AccountType, c.AccountStatus })));
            CreateMap<Employee, EmployeeCreatDto>().ReverseMap();
            CreateMap<Employee, EmployeeSelectDto>().ReverseMap();
               
            CreateMap<Account, AccountCreatDto>().ReverseMap();
            CreateMap<Account, AccountSelectDto>();
                       
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
