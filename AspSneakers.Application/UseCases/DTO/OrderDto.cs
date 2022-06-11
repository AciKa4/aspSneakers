using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.DTO
{
    public class OrderDto : BaseDto
    {
        public int UserId { get; set; }
     
        public decimal Total { get; set; }
        public IEnumerable<OrderLineDto> OrderLines { get; set; } = new List<OrderLineDto>();
    }

    public class GetOrdersDto : BaseDto
    {
        public int UserId { get; set; }

        public decimal Total { get; set; }
        public IEnumerable<GetOrderLinesDto> OrderLines { get; set; } = new List<GetOrderLinesDto>();

    }

}
