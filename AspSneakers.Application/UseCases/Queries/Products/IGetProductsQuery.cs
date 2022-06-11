using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Application.UseCases.Queries.Products
{
    public interface IGetProductsQuery : IQuery<BasePagedSearch, PagedResponse<ProductDto>>
    {
    }
}
