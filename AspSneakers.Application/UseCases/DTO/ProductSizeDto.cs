using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO
{
    public class ProductSizeDto : BaseDto
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public int Number { get; set; }
    }
}
