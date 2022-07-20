using MyApi.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace MyApi.Infrastructure.Data.Context
{
    public class DbPostContext : DbContext
    {
        public DbPostContext(DbContextOptions<DbPostContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>();
        }
    }
}
