using bancodot.Service.DTOs.AbstractionsDtos;
using System.Collections.Generic;

namespace bancodot.Service.DTOs
{
    public class ClientSelectDto : ClientDto
    {
        public object Accounts { get; set; }

        public AddressDto Address { get; set; }
    }
}
