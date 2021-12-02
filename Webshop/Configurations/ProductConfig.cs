﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Webshop.Models;

namespace Webshop.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.ProductId);

            builder
                .HasOne(c => c.Category)
                .WithMany(p => p.Products);

            builder
                .HasOne(o => o.OrderProducts)
                .WithMany(p => p.Products);
        }
    }
}
