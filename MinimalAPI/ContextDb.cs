
namespace MinimalAPI
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MinimalAPI.Models;

    internal class ContextDb : IdentityDbContext<User>
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
