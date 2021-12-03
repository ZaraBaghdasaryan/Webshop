using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webshop.Models;

namespace Webshop.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(p => p.OrderId);

            builder
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders);

            builder
                .HasOne(s => s.ShoppingCart)
                .WithOne(o => o.Order);
        }
    }
}
