using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bancodot.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StretAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agency", x => x.Id);
                    table.ForeignKey(
                        name: "fk_agency_endereco",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirtDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genre = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    AddressId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                    table.ForeignKey(
                        name: "fk_cliente_endereco",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enrollment = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdmissionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    dismissalDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Occupation = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    Salary = table.Column<float>(type: "float(12,0)", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    AgencyId = table.Column<int>(type: "int(11)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirtDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genre = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    AddressId = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employers", x => x.Id);
                    table.ForeignKey(
                        name: "fk_employee_agency",
                        column: x => x.AgencyId,
                        principalTable: "agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_employee_endereco",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountNumber = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgencyId = table.Column<int>(type: "int(11)", nullable: false),
                    ManagerId = table.Column<int>(type: "int(11)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClientId = table.Column<int>(type: "int(11)", nullable: false),
                    Balance = table.Column<float>(type: "float(12,0)", nullable: false),
                    SpecialLimit = table.Column<float>(type: "float(12,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                    table.ForeignKey(
                        name: "fk_account_agency",
                        column: x => x.AgencyId,
                        principalTable: "agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_client",
                        column: x => x.ClientId,
                        principalTable: "client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_account_manager",
                        column: x => x.ManagerId,
                        principalTable: "employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AgencyId",
                table: "account",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ClientId",
                table: "account",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_ManagerId",
                table: "account",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "fk_agency_endereco",
                table: "agency",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "fk_cliente_endereco",
                table: "client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "fk_employee_endereco",
                table: "employers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_AgencyId",
                table: "employers",
                column: "AgencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "employers");

            migrationBuilder.DropTable(
                name: "agency");

            migrationBuilder.DropTable(
                name: "address");
        }
    }
}
