using Microsoft.EntityFrameworkCore;
using pba_api.Models;
using pba_api.Models.EstimateSheetModel;
using pba_api.Models.UserModel;
using System.Reflection.Metadata;

namespace pba_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new EstimateSheetEntityTypeConfiguration().Configure(modelBuilder.Entity<EstimateSheet>());
        }

        public DbSet<Employee> Employees{ get; set; }
        public DbSet<User> Users { get; set; }
    }
}
