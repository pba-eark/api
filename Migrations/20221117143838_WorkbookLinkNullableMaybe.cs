using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class WorkbookLinkNullableMaybe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkbookLink",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EstimateSheets",
                keyColumn: "WorkbookLink",
                keyValue: null,
                column: "WorkbookLink",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "WorkbookLink",
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
        }
    }
}
