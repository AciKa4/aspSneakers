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
    public class PriceProductConfiguration : IEntityTypeConfiguration<PriceProduct>
    {
        public void Configure(EntityTypeBuilder<PriceProduct> builder)
        {
            builder.Property(x => x.Price).IsRequired();

        }
    }
}
