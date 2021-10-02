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
            .ForMember(a => a.Accounts, opts => opts.MapFrom(a => a.Accounts.Select
            (c => new { c.AccountNumber, c.AccountType, c.AccountStatus })));
            CreateMap<Employee, EmployeeCreatDto>().ReverseMap();
            CreateMap<Employee, EmployeeSelectDto>()
               .ForMember(a => a.AgencyNumber, opts => opts.MapFrom(a => a.Agency.Code))
               .ForMember(a => a.Agency, opts => opts.MapFrom(a => a.Agency.Name));

            CreateMap<Account, AccountCreatDto>().ReverseMap();
            CreateMap<Account, AccountSelectDto>()
                .ForMember(a => a.Name, opts => opts.MapFrom(a => a.Client.Name))
                .ForMember(a => a.Cpf, opts => opts.MapFrom(a => a.Client.Cpf))
                .ForMember(a => a.AgencyNumber, opts => opts.MapFrom(a => a.Agency.Code))
                .ForMember(a => a.Agency, opts => opts.MapFrom(a => a.Agency.Name));

            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
