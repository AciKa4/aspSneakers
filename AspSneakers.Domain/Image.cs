using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Domain
{
    public class Image : Entity
    {
        public int ProductId { get; set; }
        public string url { get; set; }


        public virtual Product Product { get; set; }
    }
}
