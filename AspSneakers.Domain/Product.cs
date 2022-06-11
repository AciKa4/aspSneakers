using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int  BrandId{ get; set; }
        public int  GenderId{ get; set; }
        public string Description { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Gender Gender { get; set; }

        public virtual ICollection<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
        public virtual ICollection<PriceProduct> ProductPrices { get; set; } = new List<PriceProduct>();
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
