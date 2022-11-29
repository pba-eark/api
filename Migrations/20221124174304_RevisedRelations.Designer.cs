﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pba_api.Data;

#nullable disable

namespace pba_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221124174304_RevisedRelations")]
    partial class RevisedRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("pba_api.Models.AdditionalExpensesModel.AdditionalExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Continuous")
                        .HasColumnType("bit");

                    b.Property<int?>("EstimateSheetId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EstimateSheetId");

                    b.ToTable("AdditionalExpenses");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.CustomerModel.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.EpicModel.Epic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EpicName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("EpicStatusId")
                        .HasColumnType("int");

                    b.Property<int>("EstimateSheetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EpicStatusId");

                    b.HasIndex("EstimateSheetId");

                    b.ToTable("Epics");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.EpicStatusModel.EpicStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EpicStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EpicStatus");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetModel.EstimateSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("JiraBoardId")
                        .HasColumnType("int");

                    b.Property<string>("JiraLink")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("SheetName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("SheetStatusId")
                        .HasColumnType("int");

                    b.Property<string>("WireframeLink")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("WorkbookLink")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SheetStatusId");

                    b.ToTable("EstimateSheets");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetRiskProfileModel.EstimateSheetRiskProfile", b =>
                {
                    b.Property<int>("EstimateSheetId")
                        .HasColumnType("int");

                    b.Property<int>("RiskProfileId")
                        .HasColumnType("int");

                    b.HasKey("EstimateSheetId", "RiskProfileId");

                    b.HasIndex("RiskProfileId");

                    b.ToTable("EstimateSheetRiskProfiles");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetUserModel.EstimateSheetUser", b =>
                {
                    b.Property<int>("EstimateSheetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EstimateSheetId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EstimateSheetUsers");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.RiskProfileModel.RiskProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Global")
                        .HasColumnType("bit");

                    b.Property<int>("Percentage")
                        .HasColumnType("int");

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RiskProfiles");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.RoleModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("HourlyWage")
                        .HasColumnType("float");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.SheetStatusModel.SheetStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SheetStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SheetStatus");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.TaskModel.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EstimateReasoning")
                        .HasMaxLength(2400)
                        .HasColumnType("varchar(2400)");

                    b.Property<int>("EstimateSheetId")
                        .HasColumnType("int");

                    b.Property<float>("HourEstimate")
                        .HasColumnType("float");

                    b.Property<ulong>("OptOut")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("RiskProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .HasMaxLength(2400)
                        .HasColumnType("varchar(2400)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("EstimateSheetId");

                    b.HasIndex("RiskProfileId");

                    b.HasIndex("RoleId");

                    b.ToTable("Tasks");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.UserModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2400)
                        .HasColumnType("varchar(2400)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_danish_ci");
                });

            modelBuilder.Entity("pba_api.Models.AdditionalExpensesModel.AdditionalExpense", b =>
                {
                    b.HasOne("pba_api.Models.EstimateSheetModel.EstimateSheet", "EstimateSheet")
                        .WithMany("AdditionalExpenses")
                        .HasForeignKey("EstimateSheetId");

                    b.Navigation("EstimateSheet");
                });

            modelBuilder.Entity("pba_api.Models.EpicModel.Epic", b =>
                {
                    b.HasOne("pba_api.Models.EpicStatusModel.EpicStatus", "EpicStatus")
                        .WithMany("Epics")
                        .HasForeignKey("EpicStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pba_api.Models.EstimateSheetModel.EstimateSheet", "EstimateSheet")
                        .WithMany("Epics")
                        .HasForeignKey("EstimateSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EpicStatus");

                    b.Navigation("EstimateSheet");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetModel.EstimateSheet", b =>
                {
                    b.HasOne("pba_api.Models.CustomerModel.Customer", "Customer")
                        .WithMany("EstimateSheets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("pba_api.Models.SheetStatusModel.SheetStatus", "SheetStatus")
                        .WithMany("EstimateSheets")
                        .HasForeignKey("SheetStatusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Customer");

                    b.Navigation("SheetStatus");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetRiskProfileModel.EstimateSheetRiskProfile", b =>
                {
                    b.HasOne("pba_api.Models.EstimateSheetModel.EstimateSheet", "EstimateSheet")
                        .WithMany("EstimateSheetRiskProfiles")
                        .HasForeignKey("EstimateSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pba_api.Models.RiskProfileModel.RiskProfile", "RiskProfile")
                        .WithMany("EstimateSheetRiskProfiles")
                        .HasForeignKey("RiskProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimateSheet");

                    b.Navigation("RiskProfile");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetUserModel.EstimateSheetUser", b =>
                {
                    b.HasOne("pba_api.Models.EstimateSheetModel.EstimateSheet", "EstimateSheet")
                        .WithMany("EstimateSheetUsers")
                        .HasForeignKey("EstimateSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pba_api.Models.UserModel.User", "User")
                        .WithMany("EstimateSheetUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstimateSheet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("pba_api.Models.TaskModel.Task", b =>
                {
                    b.HasOne("pba_api.Models.EstimateSheetModel.EstimateSheet", "EstimateSheet")
                        .WithMany("Tasks")
                        .HasForeignKey("EstimateSheetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pba_api.Models.RiskProfileModel.RiskProfile", "RiskProfile")
                        .WithMany("Tasks")
                        .HasForeignKey("RiskProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pba_api.Models.RoleModel.Role", "Role")
                        .WithMany("Tasks")
                        .HasForeignKey("RoleId");

                    b.Navigation("EstimateSheet");

                    b.Navigation("RiskProfile");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("pba_api.Models.CustomerModel.Customer", b =>
                {
                    b.Navigation("EstimateSheets");
                });

            modelBuilder.Entity("pba_api.Models.EpicStatusModel.EpicStatus", b =>
                {
                    b.Navigation("Epics");
                });

            modelBuilder.Entity("pba_api.Models.EstimateSheetModel.EstimateSheet", b =>
                {
                    b.Navigation("AdditionalExpenses");

                    b.Navigation("Epics");

                    b.Navigation("EstimateSheetRiskProfiles");

                    b.Navigation("EstimateSheetUsers");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("pba_api.Models.RiskProfileModel.RiskProfile", b =>
                {
                    b.Navigation("EstimateSheetRiskProfiles");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("pba_api.Models.RoleModel.Role", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("pba_api.Models.SheetStatusModel.SheetStatus", b =>
                {
                    b.Navigation("EstimateSheets");
                });

            modelBuilder.Entity("pba_api.Models.UserModel.User", b =>
                {
                    b.Navigation("EstimateSheetUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
