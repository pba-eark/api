using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class TaskAndEpicRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_EstimateSheets_EstimateSheetId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "EstimateSheetId",
                table: "Tasks",
                newName: "EpicId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_EstimateSheetId",
                table: "Tasks",
                newName: "IX_Tasks_EpicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Epics_EpicId",
                table: "Tasks",
                column: "EpicId",
                principalTable: "Epics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Epics_EpicId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "EpicId",
                table: "Tasks",
                newName: "EstimateSheetId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_EpicId",
                table: "Tasks",
                newName: "IX_Tasks_EstimateSheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_EstimateSheets_EstimateSheetId",
                table: "Tasks",
                column: "EstimateSheetId",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
