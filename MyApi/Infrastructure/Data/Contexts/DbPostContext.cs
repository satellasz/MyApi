using MyApi.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyApi.Infrastructure.Data.Contexts
{
    public class DbPostContext : IdentityDbContext<ApplicationUser>
    {
        public DbPostContext(DbContextOptions<DbPostContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<ApplicationRole> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users").HasKey(t => t.Id);

            modelBuilder.Entity<Post>();
        }
    }
}
