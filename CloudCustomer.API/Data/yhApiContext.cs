using Microsoft.EntityFrameworkCore;
using CloudCustomer.API.Models;

namespace CloudCustomer.API.Data
{
    public class yhApiContext : DbContext
    {
        public yhApiContext(DbContextOptions<yhApiContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Address>().ToTable("Address");
        }
    }
}