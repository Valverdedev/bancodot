using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace bancodot.Infra.Data.Mapping
{
    class AgencyMap : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> entity)
        {
            entity.ToTable("agency");

            entity.HasIndex(e => e.AddressId, "fk_agency_endereco");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.AddressId).HasColumnType("int(11)");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(5);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Agencies)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("fk_agency_endereco");
        }
    }
}
