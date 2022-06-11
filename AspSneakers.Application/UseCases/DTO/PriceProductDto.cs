using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO
{
    public class PriceProductDto 
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
      
        public bool isDeleted { get; set; }
    }

}
