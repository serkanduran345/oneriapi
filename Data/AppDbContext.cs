namespace OneriApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using OneriApi.Entities;


    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Shoe> Shoes { get; set; }

        public DbSet<ShoeSize> ShoeSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shoe>()
                .HasMany(x => x.Sizes)
                .WithOne(x => x.Shoe)
                .HasForeignKey(x => x.ShoeId);

            modelBuilder.Entity<ShoeSize>()
                .HasIndex(x => new { x.ShoeId, x.Size })
                .IsUnique();
        }
    }
}
