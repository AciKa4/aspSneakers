using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Domain
{
    public class Size : Entity
    {
        public int Number { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();


    }
}
