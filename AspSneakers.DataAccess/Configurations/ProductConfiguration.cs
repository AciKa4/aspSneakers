using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");


            builder.HasIndex(x => x.Name);


            builder.HasMany(x => x.Categories)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductSizes)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);


            builder.HasMany(x => x.ProductPrices)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.Images)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);


        }
    }
}
