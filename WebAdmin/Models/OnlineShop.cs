namespace WebAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineShop : DbContext
    {
        public OnlineShop()
            : base("name=OnlineShop")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.Total_amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Order_Detail)
                .WithOptional(e => e.Order)
                .HasForeignKey(e => e.Order_id)
                .WillCascadeOnDelete();

           

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order_Detail)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.Product_id)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete();
        }
    }
}
