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
        public AccountTypeEnum AccountType { get; set; }
        public AccountStatusEnum AccountStatus { get; set; }
        public string AgencyNumber { get; set; }
        public string Agency { get; set; }
        public double Balance { get; set; }
        public double SpecialLimit { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
    }
} 
