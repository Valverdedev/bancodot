using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace bancodot.Infra.Data.Mapping
{
    class AgencyMap : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.ToTable("Agency");
            builder.HasIndex(prop => prop.AddressId, "fk_agency_endereco");
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Code)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Code")
                .HasColumnType("varchar(5)");

            builder.Property(prop => prop.AddressId)
                    .HasColumnType("int(11)")
                    .HasColumnName("AddressId");

            builder.HasOne(prop => prop.Address)
              .WithMany()
              .HasForeignKey(prop => prop.AddressId)
              .HasConstraintName("fk_agency_endereco");

            builder.HasMany(prop => prop.Employers);
        }
    }
}
