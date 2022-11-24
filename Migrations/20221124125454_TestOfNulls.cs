using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class TestOfNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId",
                principalTable: "SheetStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId",
                principalTable: "SheetStatus",
                principalColumn: "Id");
        }
    }
}
