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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

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

            modelBuilder.Entity<Customer>()
                .Property(c=> c.Id)
                .HasMaxLength(5)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "Chai" },
                new Product { Id = 2, Name = "Chang" },
                new Product { Id = 3, Name = "Aniseed Syrup" },
                new Product { Id = 4, Name = "Chef Anton's" }
                );

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id = "ALFKI", Name = "Alfred's F." },
                new Customer { Id = "ANATR", Name = "Ana T." },
                new Customer { Id = "ANTON", Name = "Antonio M." }
                );

        }
    }
}
