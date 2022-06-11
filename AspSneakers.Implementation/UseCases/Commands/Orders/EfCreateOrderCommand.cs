using AspSneakers.Application.UseCases.Commands.Orders;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Orders
{
    public class EfCreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
      
        public EfCreateOrderCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 32;

        public string Name => "Create order.";

        public string Description => "Creating order by forwarding  userId and orderlines(quantity,productId and size number)";

        public void Execute(OrderDto request)
        {

            var order = new Order
            {
                UserId = request.UserId,
                OrderLines = request.OrderLines.Select(x => new OrderLine{
                    ProductSizeId = Context.ProductSizes.Where(z => z.Size.Number == x.Number).Select(z => z.Id).FirstOrDefault(),
                    Quantity = x.Quantity,
                    Price = Context.PriceProducts.Where(y => y.ProductId == x.ProductId && !y.isDeleted).Select(s => s.Price).FirstOrDefault(),
                    ProductName = Context.Products.Where(y => y.Id == x.ProductId).Select(s => s.Name).FirstOrDefault()
                }).ToList()
            };

            order.Total = order.OrderLines.Select(x => x.Price * x.Quantity).Sum();


            Context.Orders.Add(order);
            Context.OrderLines.AddRange(order.OrderLines);
            Context.SaveChanges();
        }
    }
}
