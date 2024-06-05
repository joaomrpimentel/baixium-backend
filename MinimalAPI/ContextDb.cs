
namespace MinimalAPI
{
    using Microsoft.EntityFrameworkCore;

    internal class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(article => article.Articles)
                .WithOne(article => article.User)
                .HasForeignKey(user => user.userId);
        }
    }
}
