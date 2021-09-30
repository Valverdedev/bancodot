using System;

namespace bancodot.Domain.Entities.Abstracts
{
    public abstract class PersonAbstract : BaseEntity

    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirtDate { get; set; }
        public GenreEnum Genre { get; set; }   
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
    
    }
}