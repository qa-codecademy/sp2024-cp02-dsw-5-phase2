using DropShippingWebStore_Signature.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.DataAccess
{
    public class SignatureDbContext : IdentityDbContext<IdentityUser>
    {
        public SignatureDbContext(DbContextOptions<SignatureDbContext> options) : base(options) { }

        //Dbsets
        //public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category to Products (One-to-Many)
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // Material to Products (One-to-Many)
            modelBuilder.Entity<Material>()
                .HasMany(m => m.Products)
                .WithOne(p => p.Material)
                .HasForeignKey(p => p.MaterialId);

            // User to Orders (One-to-Many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            // User to Cart (One-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);

            // Order to OrderItems (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Cart to CartItems (One-to-Many)
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);

            // CartItem and OrderItem to Product (Many-to-One)
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            //Property configurations: 
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(x => x.UnitPrice)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<Order>()
                .Property(x => x.TotalPrice)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<CartItem>()
                .Property(x => x.ItemPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Cart>()
                .Property(x => x.TotalPrice)
                .HasPrecision(18, 2);
            
            //Seeding
            modelBuilder.Entity<Material>().HasData(
                new Material { MaterialName = "Gold", Id = 1 },
                new Material { MaterialName = "Silver", Id = 2 },
                new Material { MaterialName = "Rose Gold", Id = 3 },
                new Material { MaterialName = "White Gold", Id = 4 },
                new Material { MaterialName = "Pearl", Id = 5 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryName = "Rings", Id = 1 },
                new Category { CategoryName = "Necklaces", Id = 2 },
                new Category { CategoryName = "Bracelets", Id = 3 },
                new Category { CategoryName = "Earrings", Id = 4 }
            );

        }
    }
}
