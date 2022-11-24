using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class NullableCustomerFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_EstimateSheets_Id",
                table: "Tasks");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EstimateSheetId",
                table: "Tasks",
                column: "EstimateSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_EstimateSheets_EstimateSheetId",
                table: "Tasks",
                column: "EstimateSheetId",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_EstimateSheets_EstimateSheetId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EstimateSheetId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_EstimateSheets_Id",
                table: "Tasks",
                column: "Id",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
