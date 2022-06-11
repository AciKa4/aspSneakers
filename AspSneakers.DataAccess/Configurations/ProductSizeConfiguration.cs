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
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {

            builder.HasMany(x => x.OrderLines)
                .WithOne(x => x.ProductSize)
                .HasForeignKey(x => x.ProductSizeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
