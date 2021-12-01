using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Webshop.Models;

namespace Webshop.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(p => p.CategoryId);

            builder
                .HasMany(p => p.Products)
                .WithOne(c => c.Category);
        }
    }
}
