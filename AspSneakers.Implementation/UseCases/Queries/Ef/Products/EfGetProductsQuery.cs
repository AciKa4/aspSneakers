using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries;
using AspSneakers.Application.UseCases.Queries.Products;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef.Products
{
    public class EfGetProductsQuery : EfUseCase, IGetProductsQuery
    {
        public EfGetProductsQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Search products.";

        public string Description => "";

        public PagedResponse<ProductDto> Execute(BasePagedSearch search)
        {
            var query = Context.Products.AsQueryable();
            var keyword = search.Keyword;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
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

            var response = new PagedResponse<ProductDto>();
            response.TotalCount = query.Count();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Categories = x.Categories.Select(y => new CategoryDto
                {
                    Id = y.CategoryId,
                    Name = y.Category.Name
                }),
                Price = Context.PriceProducts.Where(u => u.ProductId == x.Id && !u.isDeleted).Select(z => z.Price).FirstOrDefault(),
                Brand = new BrandDto
                {
                    Id = x.BrandId,
                    Name = x.Brand.Name
                },
                Gender = new GenderDto {
                    Id = x.GenderId,
                    Name = x.Gender.Name
                },
                Images = x.Images.Select(y => new ImageDto
                {
                    Url = y.url
                }),
                Sizes = x.ProductSizes.Select(z => new ProductSizeDto
                {
                    Stock = z.Stock,
                    Number = z.Size.Number,
                    ProductId = z.ProductId,
                    Id = z.Id,
                    SizeId = z.SizeId
                })
            }).ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;

            return response;
        }
    }
}
