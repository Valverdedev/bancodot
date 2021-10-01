using bancodot.Domain;
using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace bancodot.Infra.Data.Mapping
{
    class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("employers");

            entity.HasIndex(e => e.AgencyId, "IX_Employers_AgencyId");

            entity.HasIndex(e => e.AddressId, "fk_employee_endereco");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.AddressId).HasColumnType("int(11)");

            entity.Property(e => e.AdmissionDate).HasColumnType("datetime");

            entity.Property(e => e.AgencyId).HasColumnType("int(11)");

            entity.Property(e => e.BirtDate).HasColumnType("datetime");

            entity.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            entity.Property(e => e.DismissalDate)
                .HasColumnType("datetime")
                .HasColumnName("dismissalDate");

            entity.Property(e => e.Enrollment)
                .IsRequired()
                .HasMaxLength(7);

            entity.Property(e => e.Genre)
                .IsRequired()
                .HasMaxLength(11);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Occupation)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(e => e.Salary).HasColumnType("float(12,0)");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(15);

            entity.HasOne(d => d.Address)
                .WithMany(p => p.Employeers)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("fk_employee_endereco");

            entity.HasOne(d => d.Agency)
                .WithMany(p => p.Employers)
                .HasForeignKey(d => d.AgencyId)
                .HasConstraintName("fk_employee_agency");
        }
    }
}
