using bancodot.Domain;
using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace bancodot.Infra.Data.Mapping
{
    class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasIndex(prop => prop.AddressId, "fk_cliente_endereco");
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Cpf)
                   .HasConversion(prop => prop.ToString(), prop => prop)
                   .IsRequired()
                   .HasColumnName("Cpf")
                   .HasColumnType("varchar(11)");

            builder.Property(prop => prop.BirtDate)
                   .IsRequired()
                   .HasColumnName("BirthDate")
                   .HasColumnType("DateTime");

            builder.Property(prop => prop.Genre)
                   .IsRequired()
                   .HasConversion(prop => prop.ToString(), prop => (GenreEnum)Enum.Parse(typeof(GenreEnum), prop))
                   .HasColumnName("Genre")
                   .HasColumnType("varchar(11)");

            builder.Property(prop => prop.Name)
                   .HasConversion(prop => prop.ToString(), prop => prop)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("varchar(100)");

            builder.Property(prop => prop.AddressId)
                     .HasColumnType("int(11)")
                     .HasColumnName("AddressId");

            builder.HasOne(prop=> prop.Address)
                   .WithMany()
                   .HasForeignKey(prop => prop.AddressId)
                   .HasConstraintName("fk_cliente_endereco");

            

        }
    }
}
