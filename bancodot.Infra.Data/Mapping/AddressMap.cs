using bancodot.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace bancodot.Infra.Data.Mapping
{
    class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.State)
                 .HasConversion(prop => prop.ToString(), prop => (StateEnum)Enum.Parse(typeof(StateEnum), prop))
                 .IsRequired()
                 .HasColumnName("Estate")
                 .HasColumnType("varchar(2)");

            builder.Property(prop => prop.City)
                  .HasConversion(prop => prop.ToString(), prop => prop)
                  .IsRequired()
                  .HasColumnName("City")
                  .HasColumnType("varchar(70)");

            builder.Property(prop => prop.StretAddress)
                   .HasConversion(prop => prop.ToString(), prop => prop)
                   .IsRequired()
                   .HasColumnName("StretAddress")
                   .HasColumnType("varchar(100)");
                       

            builder.Property(prop => prop.PostalCode)
                   .HasConversion(prop => prop.ToString(), prop => prop)
                   .IsRequired()
                   .HasColumnName("PostalCode")
                   .HasColumnType("varchar(10)");

          
        }
    }
}
