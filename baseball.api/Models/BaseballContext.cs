using Microsoft.EntityFrameworkCore;

namespace Baseball.Models
{
    public sealed class BaseballContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseballContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.Username);
        }
    }
}
