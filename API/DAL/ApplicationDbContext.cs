using API.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.DAL
{
    public class ApplicationDbContext : IdentityUserContext<User, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishInCart> DishInCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===== User ↔ Orders (One-to-Many) =====
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== User ↔ Ratings (One-to-Many) =====
            modelBuilder.Entity<User>()
                .HasMany(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== User ↔ DishInCart (One-to-Many) =====
            modelBuilder.Entity<User>()
                .HasMany(u => u.CartItems)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== Dish ↔ DishInCart (One-to-Many) =====
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.DishInCarts)
                .WithOne(c => c.Dish)
                .HasForeignKey(c => c.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== Dish ↔ Ratings (One-to-Many) =====
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.Ratings)
                .WithOne(r => r.Dish)
                .HasForeignKey(r => r.DishId)
                .OnDelete(DeleteBehavior.Cascade);

            // ===== Order ↔ DishInCart (One-to-Many) =====
            modelBuilder.Entity<Order>()
                .HasMany(o => o.DishInCarts)
                .WithOne(d => d.Order)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

            // ===== Dish Category (Enum as int) =====
            modelBuilder.Entity<Dish>()
                .Property(d => d.Category)
                .HasConversion<int>();

            // ===== Order Status (Enum as int) =====
            modelBuilder.Entity<Order>()
                .Property(o => o.Status)
                .HasConversion<int>();
        }
    }
}
