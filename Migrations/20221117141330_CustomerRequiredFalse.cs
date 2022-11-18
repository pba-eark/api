using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class CustomerRequiredFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
