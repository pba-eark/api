using Microsoft.EntityFrameworkCore;
using pba_api.Models;

namespace pba_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees{ get; set; }

        public DbSet<User> Users { get; set; }
    }
}
