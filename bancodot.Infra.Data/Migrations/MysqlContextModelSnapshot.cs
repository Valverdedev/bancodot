﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bancodot.Infra.Data.Context;

namespace bancodot.Infra.Data.Migrations
{
    [DbContext(typeof(MysqlContext))]
    partial class MysqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("AgencyEmployee", b =>
                {
                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<int>("EmployersId")
                        .HasColumnType("int");

                    b.HasKey("AgencyId", "EmployersId");

                    b.HasIndex("EmployersId");

                    b.ToTable("AgencyEmployee");
                });

            modelBuilder.Entity("bancodot.Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasColumnName("City");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("PostalCode");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("Estate");

                    b.Property<string>("StretAddress")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("StretAddress");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(6)")
                        .HasColumnName("AccountNumber");

                    b.Property<string>("AccountStatus")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("AccountStatus");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Estate");

                    b.Property<int>("AgencyId")
                        .HasColumnType("int(5)");

                    b.Property<float>("Balance")
                        .HasColumnType("float")
                        .HasColumnName("Balance");

                    b.Property<int>("ClientId")
                        .HasColumnType("int(5)");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int(5)");

                    b.Property<DateTime>("OpeningDate")
                        .HasColumnType("datetime")
                        .HasColumnName("OpeningDate");

                    b.Property<float>("SpecialLimit")
                        .HasColumnType("float")
                        .HasColumnName("SpecialLimite");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AgencyId" }, "IX_Account_AgencyId");

                    b.HasIndex(new[] { "ClientId" }, "IX_Account_ClientId");

                    b.HasIndex(new[] { "ManagerId" }, "IX_Account_ManagerId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int(11)")
                        .HasColumnName("AddressId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AddressId" }, "fk_agency_endereco");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int(11)")
                        .HasColumnName("AddressId");

                    b.Property<DateTime>("BirtDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Genre");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AddressId" }, "fk_cliente_endereco");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int(11)")
                        .HasColumnName("AddressId");

                    b.Property<DateTime>("AdmissionDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("AdmissionDate");

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirtDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("BirthDate");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime?>("DismissalDate")
                        .HasColumnType("DateTime")
                        .HasColumnName("dismissalDate");

                    b.Property<string>("Enrollment")
                        .IsRequired()
                        .HasColumnType("varchar(7)")
                        .HasColumnName("Enrollment");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Genre");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Occupation");

                    b.Property<float>("Salary")
                        .HasColumnType("float")
                        .HasColumnName("Salary");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("Satus");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Employeers");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AgencyEmployee", b =>
                {
                    b.HasOne("bancodot.Domain.Entities.Agency", null)
                        .WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bancodot.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Account", b =>
                {
                    b.HasOne("bancodot.Domain.Entities.Agency", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyId")
                        .HasConstraintName("fk_Account_Agency")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bancodot.Domain.Entities.Client", "Client")
                        .WithMany("Account")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bancodot.Domain.Entities.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("fk_Account_Manager")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("Client");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Agency", b =>
                {
                    b.HasOne("bancodot.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("fk_agency_endereco");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Client", b =>
                {
                    b.HasOne("bancodot.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("fk_cliente_endereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Employee", b =>
                {
                    b.HasOne("bancodot.Domain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("fk_employee_address")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("bancodot.Domain.Entities.Client", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
