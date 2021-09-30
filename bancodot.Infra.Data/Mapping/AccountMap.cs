using bancodot.Domain;
using bancodot.Domain.Entities;
using bancodot.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace bancodot.Infra.Data.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
       
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasIndex(e => e.AgencyId, "IX_Account_AgencyId");

            builder.HasIndex(e => e.ManagerId, "IX_Account_ManagerId");

            builder.HasIndex(e => e.ClientId, "IX_Account_ClientId");

            builder.Property(prop => prop.AgencyId).HasColumnType("int(5)");
            builder.Property(prop => prop.ClientId).HasColumnType("int(5)");
            builder.Property(prop => prop.ManagerId).HasColumnType("int(5)");


            builder.Property(e => e.Id).HasColumnType("int(11)");


            builder.HasKey(prop => prop.Id);
           

            builder.Property(prop => prop.AccountType)
                 .HasConversion(prop => prop.ToString(), prop => (AccountTypeEnum)Enum.Parse(typeof(AccountTypeEnum), prop))
                 .IsRequired()
                 .HasColumnName("Estate")
                 .HasColumnType("varchar(15)");

            builder.Property(prop => prop.AccountStatus)
                .HasConversion(prop => prop.ToString(), prop => (AccountStatusEnum)Enum.Parse(typeof(AccountStatusEnum), prop))
                .IsRequired()
                .HasColumnName("AccountStatus")
                .HasColumnType("varchar(15)");

            builder.Property(prop => prop.AccountNumber)
                   .IsRequired()
                   .HasColumnName("AccountNumber")
                   .HasColumnType("varchar(6)");

            builder.Property(prop => prop.Balance)
                  .IsRequired()
                  .HasColumnName("Balance")
                  .HasColumnType("float");

     
            builder.Property(prop => prop.SpecialLimit)
                   .IsRequired()
                   .HasColumnName("SpecialLimite")
                   .HasColumnType("float");

            builder.Property(prop => prop.OpeningDate)
                   .IsRequired()
                   .HasColumnName("OpeningDate")
                   .HasColumnType("datetime");

            builder.HasOne(d => d.Agency)
                      .WithMany()
                      .HasForeignKey(d => d.AgencyId)
                      .HasConstraintName("fk_Account_Agency");
/*
            builder.HasOne(d => d.Client)
                .WithMany()
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("fk_Account_Client");
*/
            builder.HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_Account_Manager");


        }
    }
    }

