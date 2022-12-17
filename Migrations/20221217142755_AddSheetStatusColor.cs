using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class AddSheetStatusColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SheetStatusColor",
                table: "SheetStatus",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_danish_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SheetStatusColor",
                table: "SheetStatus");
        }
    }
}
