using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class AddUserIdToEpic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Epics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Epics_UserId",
                table: "Epics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_Users_UserId",
                table: "Epics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Epics_Users_UserId",
                table: "Epics");

            migrationBuilder.DropIndex(
                name: "IX_Epics_UserId",
                table: "Epics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Epics");
        }
    }
}
