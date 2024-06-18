
namespace MinimalAPI
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    internal class ContextDb : IdentityDbContext<AppUser>
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
