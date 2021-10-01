using bancodot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace bancodot.Infra.Data.Mapping
{
    class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {


            entity.ToTable("address");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(70);

            entity.Property(e => e.State)
                .IsRequired()
                .HasMaxLength(2);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.StretAddress)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
