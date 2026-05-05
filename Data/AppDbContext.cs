using Microsoft.EntityFrameworkCore;
using The_IT_book_online_shop.Models;

namespace The_IT_book_online_shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LikedBook> LikedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<LikedBook>()
                .HasIndex(x => new { x.UserId, x.BookId })
                .IsUnique();
        }
    }
}