using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO
{
    public class OrderLineDto : BaseDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int Number { get; set; }
    }
    public class GetOrderLinesDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int ProductSizeId { get; set; }
        public decimal Price { get; set; }
    }
}
