using bancodot.Domain;
using System;

namespace bancodot.Service.DTOs.AbstractionsDtos
{
    public abstract class PersonDto
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
       
    }
}
