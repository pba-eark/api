using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class AddSheetRoleRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstimateSheetRoles",
                columns: table => new
                {
                    EstimateSheetId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateSheetRoles", x => new { x.EstimateSheetId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EstimateSheetRoles_EstimateSheets_EstimateSheetId",
                        column: x => x.EstimateSheetId,
                        principalTable: "EstimateSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimateSheetRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateSheetRoles_RoleId",
                table: "EstimateSheetRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstimateSheetRoles");
        }
    }
}
