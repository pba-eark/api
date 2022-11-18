using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class EstimateSheetNullables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_Customers_CustomerId",
                table: "EstimateSheets");

            migrationBuilder.AlterColumn<string>(
                name: "WireframeLink",
                table: "EstimateSheets",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "JiraLink",
                table: "EstimateSheets",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

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

            migrationBuilder.UpdateData(
                table: "EstimateSheets",
                keyColumn: "WireframeLink",
                keyValue: null,
                column: "WireframeLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "WireframeLink",
                table: "EstimateSheets",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.UpdateData(
                table: "EstimateSheets",
                keyColumn: "JiraLink",
                keyValue: null,
                column: "JiraLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "JiraLink",
                table: "EstimateSheets",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldMaxLength: 250,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

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
