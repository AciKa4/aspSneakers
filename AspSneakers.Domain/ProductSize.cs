using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Domain
{
    public class ProductSize : Entity
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int Stock { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
