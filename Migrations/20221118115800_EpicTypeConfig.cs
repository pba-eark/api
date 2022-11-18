using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class EpicTypeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Epics_EstimateSheets_Id",
                table: "Epics");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Epics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Epics_EstimateSheetId",
                table: "Epics",
                column: "EstimateSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_EstimateSheets_EstimateSheetId",
                table: "Epics",
                column: "EstimateSheetId",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Epics_EstimateSheets_EstimateSheetId",
                table: "Epics");

            migrationBuilder.DropIndex(
                name: "IX_Epics_EstimateSheetId",
                table: "Epics");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Epics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_EstimateSheets_Id",
                table: "Epics",
                column: "Id",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
