using Microsoft.EntityFrameworkCore;
using DotNetSqlApp.Models;

namespace DotNetSqlApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
