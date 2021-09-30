using bancodot.Domain.Entities;
using bancodot.Service.DTOs.AbstractionsDtos;
using System.Collections.Generic;

namespace bancodot.Service.DTOs
{
    public class AgencySelectDto : AgencyDto
    {
       
        public AddressDto Address { get; set; }
    }
}
