using CleanArchitectureFullApplication.Main.Entities;
using CleanArchitectureFullApplication.Sales.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CleanArchitectureFullApplication.EFCore.DataContext
{
    public class CleanArchitectureSalesContext : DbContext
    {
        public CleanArchitectureSalesContext(DbContextOptions<CleanArchitectureSalesContext> options) 
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //configurar las relaciones y propiedades de las tablas
            modelBuilder.Entity<Order>()
                .Property(o=>o.CustomerId).IsRequired().HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Order>()
                .Property(o=>o.ShipAddress).IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Order>()
                .Property(o=>o.ShipCity).HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry).HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipPostalCode).HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
        }
    }
}
