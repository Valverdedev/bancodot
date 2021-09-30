using Microsoft.EntityFrameworkCore.Migrations;

namespace bancodot.Infra.Data.Migrations
{
    public partial class B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeers_Agency_AgencyId",
                table: "Employeers");

            migrationBuilder.DropIndex(
                name: "IX_Employeers_AgencyId",
                table: "Employeers");

            migrationBuilder.CreateTable(
                name: "AgencyEmployee",
                columns: table => new
                {
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    EmployersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyEmployee", x => new { x.AgencyId, x.EmployersId });
                    table.ForeignKey(
                        name: "FK_AgencyEmployee_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyEmployee_Employeers_EmployersId",
                        column: x => x.EmployersId,
                        principalTable: "Employeers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AgencyEmployee_EmployersId",
                table: "AgencyEmployee",
                column: "EmployersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Employeers_AgencyId",
                table: "Employeers",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeers_Agency_AgencyId",
                table: "Employeers",
                column: "AgencyId",
                principalTable: "Agency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
