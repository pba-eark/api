using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class RevisedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                table: "AdditionalExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Epics_EpicStatus_Id",
                table: "Epics");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RiskProfiles_Id",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Roles_Id",
                table: "Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                table: "Tasks",
                type: "varchar(2400)",
                maxLength: 2400,
                nullable: true,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(2400)",
                oldMaxLength: 2400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EstimateReasoning",
                table: "Tasks",
                type: "varchar(2400)",
                maxLength: 2400,
                nullable: true,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(2400)",
                oldMaxLength: 2400)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "Tasks",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_danish_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Epics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EstimateSheetId",
                table: "AdditionalExpenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RiskProfileId",
                table: "Tasks",
                column: "RiskProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RoleId",
                table: "Tasks",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Epics_EpicStatusId",
                table: "Epics",
                column: "EpicStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                table: "AdditionalExpenses",
                column: "EstimateSheetId",
                principalTable: "EstimateSheets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_EpicStatus_EpicStatusId",
                table: "Epics",
                column: "EpicStatusId",
                principalTable: "EpicStatus",
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
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                table: "AdditionalExpenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Epics_EpicStatus_EpicStatusId",
                table: "Epics");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RiskProfiles_RiskProfileId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Roles_RoleId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RiskProfileId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RoleId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Epics_EpicStatusId",
                table: "Epics");

            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskDescription",
                keyValue: null,
                column: "TaskDescription",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                table: "Tasks",
                type: "varchar(2400)",
                maxLength: 2400,
                nullable: false,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(2400)",
                oldMaxLength: 2400,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "EstimateReasoning",
                keyValue: null,
                column: "EstimateReasoning",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "EstimateReasoning",
                table: "Tasks",
                type: "varchar(2400)",
                maxLength: 2400,
                nullable: false,
                collation: "utf8mb4_danish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(2400)",
                oldMaxLength: 2400,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Epics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EstimateSheetId",
                table: "AdditionalExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                table: "AdditionalExpenses",
                column: "EstimateSheetId",
                principalTable: "EstimateSheets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Epics_EpicStatus_Id",
                table: "Epics",
                column: "Id",
                principalTable: "EpicStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RiskProfiles_Id",
                table: "Tasks",
                column: "Id",
                principalTable: "RiskProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Roles_Id",
                table: "Tasks",
                column: "Id",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
