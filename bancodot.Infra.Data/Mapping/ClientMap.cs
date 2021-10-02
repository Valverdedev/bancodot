using bancodot.Domain;
using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace bancodot.Infra.Data.Mapping
{
    class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.ToTable("client");

            entity.HasIndex(e => e.AddressId, "fk_cliente_endereco");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.AddressId).HasColumnType("int(11)");

            entity.Property(e => e.BirtDate).HasColumnType("datetime");

            entity.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            entity.Property(e => e.Genre)
                .IsRequired()
                .HasMaxLength(11);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
/*
            entity.HasOne(d => d.Address)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("fk_cliente_endereco");
*/
        }
    }
}
