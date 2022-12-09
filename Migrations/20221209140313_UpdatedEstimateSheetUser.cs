using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class UpdatedEstimateSheetUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "EstimateSheetUsers",
                type: "varchar(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_danish_ci")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "EstimateSheetUsers");
        }
    }
}
