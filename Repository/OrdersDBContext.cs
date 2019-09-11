using Microsoft.EntityFrameworkCore;
using OrderSystem.Model.Core;

namespace OrderSystem.Repository
{
    public class OrdersDBContext : DbContext
    {
        public OrdersDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().OwnsOne(w => w.OrderDate).Property(x => x.OrderDate).HasColumnName("OrderDate");
            modelBuilder.Entity<Orders>().HasKey(w => w.OrderId);

            modelBuilder.Entity<Orders>().OwnsMany(w => w.OrderItems).Property(x => x.ProductID).HasColumnName("ProductID");
            modelBuilder.Entity<Orders>().OwnsMany(w => w.OrderItems).Property(x => x.ProductPrice).HasColumnName("ProductPrice");
            modelBuilder.Entity<Orders>().OwnsMany(w => w.OrderItems).Property(x => x.ProductQuantity).HasColumnName("ProductQuantity");

            modelBuilder.Entity<Orders>().OwnsMany(w => w.OrderItems,
                x =>
                {
                    x.HasForeignKey("OrderId");
                    x.Property<int>("OrderLineItemId").HasColumnName("OrderLineItemId");
                    x.HasKey("OrderLineItemId");
                    x.ToTable("OrderItems");
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
