using bancodot.Service.DTOs.AbstractionsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bancodot.Service.DTOs
{
   public class AgencyCreatDto : AgencyDto
    {    
        public virtual AddressDto Address { get; set; }
     }
}
