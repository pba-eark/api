using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class AddGlobals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "Global",
                table: "SheetStatus",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "Global",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "Global",
                table: "EpicStatus",
                type: "bit",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Global",
                table: "SheetStatus");

            migrationBuilder.DropColumn(
                name: "Global",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Global",
                table: "EpicStatus");
        }
    }
}
