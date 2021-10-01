using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bancodot.Infra.Data.Mapping
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
       
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("account");

            entity.HasIndex(e => e.AgencyId, "IX_Account_AgencyId");

            entity.HasIndex(e => e.ClientId, "IX_Account_ClientId");

            entity.HasIndex(e => e.ManagerId, "IX_Account_ManagerId");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.AccountNumber)
                .IsRequired()
                .HasMaxLength(6);

            entity.Property(e => e.AccountStatus)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.AgencyId).HasColumnType("int(11)");

            entity.Property(e => e.Balance).HasColumnType("float(12,0)");

            entity.Property(e => e.ClientId).HasColumnType("int(11)");


            entity.Property(e => e.ManagerId).HasColumnType("int(11)");

            entity.Property(e => e.OpeningDate).HasColumnType("datetime");

            entity.Property(e => e.SpecialLimit).HasColumnType("float(12,0)");

            entity.HasOne(d => d.Agency)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AgencyId)
                .HasConstraintName("fk_account_agency");

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("fk_account_client");

            entity.HasOne(d => d.Manager)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_account_manager");

        }
    }
    }

