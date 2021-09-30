using bancodot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bancodot.Domain
{
    public class Address : BaseEntity
    {
        public string StretAddress { get; set; }
        public StateEnum State { get; set; }
        public String PostalCode { get; set; }
        public String City { get; set; }
    }
}