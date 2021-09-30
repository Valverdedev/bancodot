using bancodot.Domain;
using bancodot.Service.DTOs.AbstractionsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancodot.Service.DTOs
{
   public class ClientCreatDto : ClientDto
    {
        public DateTime BirtDate { get; set; }
        public GenreEnum Genre { get; set; }
        public virtual AddressDto Address { get; set; }
    }
}
