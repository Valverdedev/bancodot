using bancodot.Domain;
using System;

namespace bancodot.Service.DTOs
{
    public class AddressDto
    {
        public string StretAddress { get; set; }
        public StateEnum State { get; set; }
        public String PostalCode { get; set; }
        public String City { get; set; }
    }
}
