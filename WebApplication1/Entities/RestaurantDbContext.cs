using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace WebApplication1.Entities
{
    public class RestaurantDbContext : DbContext
    {


        public RestaurantDbContext(DbContextOptions options) : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Microsoft.EntityFrameworkCore.DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Id");
                entity.Property(e => e.name).HasColumnType("nvarchar(64)");
                entity.Property(e => e.CusineType).HasColumnType("int(11)");
                entity.Property(e => e.Url).HasColumnType("nvarchar(100)");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}
