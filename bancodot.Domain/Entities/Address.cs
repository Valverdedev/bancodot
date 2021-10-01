using bancodot.Domain.Entities;
using System;
using System.Collections.Generic;

namespace bancodot.Domain
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Agencies = new HashSet<Agency>();
            Clients = new HashSet<Client>();
            Employeers = new HashSet<Employee>();
        }
        public string StretAddress { get; set; }
        public StateEnum State { get; set; }
        public String PostalCode { get; set; }
        public String City { get; set; }


        public virtual ICollection<Agency> Agencies { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employeers { get; set; }
    }
}