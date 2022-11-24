using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class NullableForReal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets");

            migrationBuilder.AlterColumn<int>(
                name: "SheetStatusId",
                table: "EstimateSheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "EstimateSheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId",
                principalTable: "SheetStatus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets");

            migrationBuilder.AlterColumn<int>(
                name: "SheetStatusId",
                table: "EstimateSheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "EstimateSheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId",
                principalTable: "SheetStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
