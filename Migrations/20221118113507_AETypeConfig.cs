using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class AETypeConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_Id",
                table: "AdditionalExpenses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "SheetStausName",
                table: "SheetStatus",
                newName: "SheetStatusName");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AdditionalExpenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalExpenses_EstimateSheetId",
                table: "AdditionalExpenses",
                column: "EstimateSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                table: "AdditionalExpenses",
                column: "EstimateSheetId",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                table: "AdditionalExpenses");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalExpenses_EstimateSheetId",
                table: "AdditionalExpenses");

            migrationBuilder.RenameColumn(
                name: "SheetStatusName",
                table: "SheetStatus",
                newName: "SheetStausName");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AdditionalExpenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_Id",
                table: "AdditionalExpenses",
                column: "Id",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
