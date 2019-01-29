using Hotels.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotels.Infrastructure.EF
{
    public class HotelsDbContext : IdentityDbContext<AppUser>
    {
        public HotelsDbContext(DbContextOptions<HotelsDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Order>().Property(x => x.Status).HasDefaultValue(Status.New);

            modelBuilder.Entity<Hotel>()
                .HasOne(a => a.AppUser)
                .WithMany(b => b.Hotels)
                .HasForeignKey(a => a.AppUserId);

            modelBuilder.Entity<Hotel>()
               .HasOne(a => a.Address)
               .WithOne(b => b.Hotel);

            modelBuilder.Entity<Hotel>()
              .HasMany(a => a.Photos)
              .WithOne(b => b.Hotel)
              .HasForeignKey(b => b.HotelId);


            //modelBuilder.Entity<Product>()
            //    .HasOne(a => a.Category)
            //    .WithMany(b => b.Products)
            //    .HasForeignKey(a => a.CategoryId)
            //    .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<OrderItem>()
            //    .HasOne(a => a.Order)
            //    .WithMany(b => b.OrderItems)
            //    .HasForeignKey(a => a.OrderId);

            //modelBuilder.Entity<OrderItem>()
            //   .HasOne(a => a.Product)
            //   .WithMany()
            //   .HasForeignKey(a => a.ProductId);

            //modelBuilder.Entity<Order>()
            //  .HasOne(a => a.AppUser)
            //  .WithMany(b => b.Orders)
            //  .HasForeignKey(a => a.AppUserId);
        }
    }
}
