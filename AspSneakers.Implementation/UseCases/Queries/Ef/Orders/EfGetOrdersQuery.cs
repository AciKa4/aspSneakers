using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Application.UseCases.Queries.Orders;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef.Orders
{
    public class EfGetOrdersQuery : EfUseCase, IGetOrdersQuery
    {
        public EfGetOrdersQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 35;
        public string Name => "Search orders.";

        public string Description => "";

        public PagedResponse<GetOrdersDto> Execute(OrderSearch search)
        {
            var query = Context.Orders.AsQueryable();

            if (search.userId != null)
            {
                query = query.Where(x => x.UserId == search.userId);
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 10;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<GetOrdersDto>();
            response.TotalCount = query.Count();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new GetOrdersDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Total = x.Total,
                OrderLines = x.OrderLines.Select(s => new GetOrderLinesDto
                {
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Price = s.Price,
                    ProductSizeId = s.ProductSizeId
                }).ToList()

            });

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
