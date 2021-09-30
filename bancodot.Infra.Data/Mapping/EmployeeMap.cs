using bancodot.Domain;
using bancodot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace bancodot.Infra.Data.Mapping
{
    class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employeers");
           // builder.HasIndex(prop => prop.AddressId, "fk_employee_address");
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Enrollment)
                   .HasConversion(prop => prop.ToString(), prop => prop)
                   .IsRequired()
                   .HasColumnName("Enrollment")
                   .HasColumnType("varchar(7)");

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

            builder.HasOne(prop => prop.Address)
                   .WithMany()
                   .HasForeignKey(prop => prop.AddressId)
                   .HasConstraintName("fk_employee_address");

            builder.Property(prop => prop.AdmissionDate)
                  .HasColumnType("DateTime")
                  .IsRequired()
                  .HasColumnName("AdmissionDate");

            builder.Property(prop => prop.DismissalDate)
                .HasColumnType("DateTime")
                .HasColumnName("dismissalDate");

            builder.Property(prop => prop.Occupation)
                  .IsRequired()
                  .HasConversion(prop => prop.ToString(), prop => (OccupationEnum)Enum.Parse(typeof(OccupationEnum), prop))
                  .HasColumnName("Occupation")
                  .HasColumnType("varchar(30)");

            builder.Property(prop => prop.Status)
                 .IsRequired()
                 .HasConversion(prop => prop.ToString(), prop => (EmployeeStatusEnum)Enum.Parse(typeof(EmployeeStatusEnum), prop))
                 .HasColumnName("Satus")
                 .HasColumnType("varchar(15)");

            builder.Property(prop => prop.Salary)
                 .IsRequired()
                 .HasColumnName("Salary")
                 .HasColumnType("float");
/*
            builder.HasOne(prop => prop.Agency)
                   .WithMany()
                   .HasForeignKey(prop => prop.AgencyId)
                   .HasConstraintName("fk_employee_agency");
                    */
        }
    }
}
