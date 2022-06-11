using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Domain
{
    public class PriceProduct : Entity
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        


        public virtual Product Product { get; set; }

    }
}
