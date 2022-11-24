using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pba_api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "EpicStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EpicStatusName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpicStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "RiskProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Global = table.Column<ulong>(type: "bit", nullable: false),
                    ProfileName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskProfiles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HourlyWage = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "SheetStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SheetStatusName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SheetStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(2400)", maxLength: 2400, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "EstimateSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SheetName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JiraBoardId = table.Column<int>(type: "int", nullable: false),
                    WorkbookLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JiraLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WireframeLink = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SheetStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimateSheets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimateSheets_SheetStatus_SheetStatusId",
                        column: x => x.SheetStatusId,
                        principalTable: "SheetStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "AdditionalExpenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExpenseName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<float>(type: "float", nullable: false),
                    Continuous = table.Column<ulong>(type: "bit", nullable: false),
                    EstimateSheetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalExpenses_EstimateSheets_EstimateSheetId",
                        column: x => x.EstimateSheetId,
                        principalTable: "EstimateSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "Epics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EpicName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimateSheetId = table.Column<int>(type: "int", nullable: false),
                    EpicStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Epics_EpicStatus_Id",
                        column: x => x.Id,
                        principalTable: "EpicStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Epics_EstimateSheets_EstimateSheetId",
                        column: x => x.EstimateSheetId,
                        principalTable: "EstimateSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "EstimateSheetRiskProfiles",
                columns: table => new
                {
                    EstimateSheetId = table.Column<int>(type: "int", nullable: false),
                    RiskProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateSheetRiskProfiles", x => new { x.EstimateSheetId, x.RiskProfileId });
                    table.ForeignKey(
                        name: "FK_EstimateSheetRiskProfiles_EstimateSheets_EstimateSheetId",
                        column: x => x.EstimateSheetId,
                        principalTable: "EstimateSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimateSheetRiskProfiles_RiskProfiles_RiskProfileId",
                        column: x => x.RiskProfileId,
                        principalTable: "RiskProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "EstimateSheetUsers",
                columns: table => new
                {
                    EstimateSheetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateSheetUsers", x => new { x.EstimateSheetId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EstimateSheetUsers_EstimateSheets_EstimateSheetId",
                        column: x => x.EstimateSheetId,
                        principalTable: "EstimateSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimateSheetUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    HourEstimate = table.Column<float>(type: "float", nullable: false),
                    EstimateReasoning = table.Column<string>(type: "varchar(2400)", maxLength: 2400, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OptOut = table.Column<ulong>(type: "bit", nullable: false),
                    TaskDescription = table.Column<string>(type: "varchar(2400)", maxLength: 2400, nullable: false, collation: "utf8mb4_danish_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstimateSheetId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RiskProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_EstimateSheets_Id",
                        column: x => x.Id,
                        principalTable: "EstimateSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_RiskProfiles_Id",
                        column: x => x.Id,
                        principalTable: "RiskProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Roles_Id",
                        column: x => x.Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_danish_ci");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalExpenses_EstimateSheetId",
                table: "AdditionalExpenses",
                column: "EstimateSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Epics_EstimateSheetId",
                table: "Epics",
                column: "EstimateSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateSheetRiskProfiles_RiskProfileId",
                table: "EstimateSheetRiskProfiles",
                column: "RiskProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateSheets_CustomerId",
                table: "EstimateSheets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateSheets_SheetStatusId",
                table: "EstimateSheets",
                column: "SheetStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateSheetUsers_UserId",
                table: "EstimateSheetUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalExpenses");

            migrationBuilder.DropTable(
                name: "Epics");

            migrationBuilder.DropTable(
                name: "EstimateSheetRiskProfiles");

            migrationBuilder.DropTable(
                name: "EstimateSheetUsers");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "EpicStatus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EstimateSheets");

            migrationBuilder.DropTable(
                name: "RiskProfiles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "SheetStatus");
        }
    }
}
