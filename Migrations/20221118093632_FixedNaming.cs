using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class FixedNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Epics_EpicStatuses_EpicStatusId",
                table: "Epics");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_SheetStatuses_SheetStatusId",
                table: "EstimateSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_EstimateSheets_Id",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_RiskProfiles_RiskProfileId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Role_RoleId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SheetStatuses",
                table: "SheetStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EpicStatuses",
                table: "EpicStatuses");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "SheetStatuses",
                newName: "SheetStatus");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "EpicStatuses",
                newName: "EpicStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Task_RoleId",
                table: "Tasks",
                newName: "IX_Tasks_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_RiskProfileId",
                table: "Tasks",
                newName: "IX_Tasks_RiskProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SheetStatus",
                table: "SheetStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EpicStatus",
                table: "EpicStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_EpicStatus_EpicStatusId",
                table: "Epics",
                column: "EpicStatusId",
                principalTable: "EpicStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId",
                principalTable: "SheetStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_EstimateSheets_Id",
                table: "Tasks",
                column: "Id",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RiskProfiles_RiskProfileId",
                table: "Tasks",
                column: "RiskProfileId",
                principalTable: "RiskProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Roles_RoleId",
                table: "Tasks",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Epics_EpicStatus_EpicStatusId",
                table: "Epics");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                table: "EstimateSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_EstimateSheets_Id",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RiskProfiles_RiskProfileId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Roles_RoleId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SheetStatus",
                table: "SheetStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EpicStatus",
                table: "EpicStatus");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "Task");

            migrationBuilder.RenameTable(
                name: "SheetStatus",
                newName: "SheetStatuses");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "EpicStatus",
                newName: "EpicStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_RoleId",
                table: "Task",
                newName: "IX_Task_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_RiskProfileId",
                table: "Task",
                newName: "IX_Task_RiskProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SheetStatuses",
                table: "SheetStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EpicStatuses",
                table: "EpicStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_EpicStatuses_EpicStatusId",
                table: "Epics",
                column: "EpicStatusId",
                principalTable: "EpicStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstimateSheets_SheetStatuses_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId",
                principalTable: "SheetStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_EstimateSheets_Id",
                table: "Task",
                column: "Id",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_RiskProfiles_RiskProfileId",
                table: "Task",
                column: "RiskProfileId",
                principalTable: "RiskProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Role_RoleId",
                table: "Task",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
