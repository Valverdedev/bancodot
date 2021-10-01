using bancodot.Domain;
using bancodot.Domain.Entities;
using bancodot.Service.DTOs.AbstractionsDtos;
using System;
using System.Text.Json.Serialization;

namespace bancodot.Service.DTOs
{
    public class AccountSelectDto
    {
        public string AccountNumber { get; set; }
     
        public Agency Agency { get; set; }
  
        public Employee Manager { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public AccountStatusEnum AccountStatus { get; set; }
       [JsonIgnore]
        public virtual Client Client { get; set; }
        public double Balance { get; set; }
        public double SpecialLimit { get; set; }

    }
} 
