﻿using Microsoft.EntityFrameworkCore;
using pba_api.Models;
using pba_api.Models.AdditionalExpenseModel;
using pba_api.Models.AdditionalExpensesModel;
using pba_api.Models.CustomerModel;
using pba_api.Models.EpicModel;
using pba_api.Models.EpicStatusModel;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.EstimateSheetRiskProfileModel;
using pba_api.Models.RiskProfileModel;
using pba_api.Models.RoleModel;
using pba_api.Models.SheetStatusModel;
using pba_api.Models.TaskModel;
using pba_api.Models.UserModel;

namespace pba_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new EstimateSheetEntityTypeConfiguration().Configure(modelBuilder.Entity<EstimateSheet>());
            new SheetStatusEntityTypeConfiguration().Configure(modelBuilder.Entity<SheetStatus>());
            new AdditionalExpenseEntityTypeConfiguration().Configure(modelBuilder.Entity<AdditionalExpense>());
            new CustomerEntityTypeConfiguration().Configure(modelBuilder.Entity<Customer>());
            new EpicEntityTypeConfiguration().Configure(modelBuilder.Entity<Epic>());
            new EpicStatusEntityTypeConfiguration().Configure(modelBuilder.Entity<EpicStatus>());
            new TaskEntityTypeConfiguration().Configure(modelBuilder.Entity<Models.TaskModel.Task>());
            new RoleEntityTypeConfiguration().Configure(modelBuilder.Entity<Role>());
            new RiskProfileEntityTypeConfiguration().Configure(modelBuilder.Entity<RiskProfile>());
            new EstimateSheetRiskProfileEntityTypeConfiguration().Configure(modelBuilder.Entity<EstimateSheetRiskProfile>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EstimateSheet> EstimateSheets { get; set; }
        public DbSet<SheetStatus> SheetStatuses { get; set; }
        public DbSet<AdditionalExpense> AdditionalExpenses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<EpicStatus> EpicStatuses { get; set; }
        public DbSet<Models.TaskModel.Task> Task { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RiskProfile> RiskProfiles { get; set; }
        public DbSet<EstimateSheetRiskProfile> EstimateSheetRiskProfiles { get; set; }
    }
}
