using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.DTO.Searches;
using AspSneakers.Application.UseCases.Queries.Products;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef.Products
{
    public class EfFindProductQuery : EfUseCase, IFindProductQuery
    {
        public EfFindProductQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Find product.";

        public string Description => "Find specific product by product's id.";

        public ProductDto Execute(int search)
        {
            var product = Context.Products.FirstOrDefault(x => x.Id == search && !x.isDeleted);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), search);
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = new BrandDto
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                },
                Gender = new GenderDto {
                    Id = product.GenderId,
                    Name = product.Gender.Name
                },
                Images = product.Images.Select(y => new ImageDto
                {
                    Url = y.url
                }),
                Categories = product.Categories.Select(y => new CategoryDto
                {
                    Id = y.CategoryId,
                    Name = y.Category.Name
                }),
                Sizes = product.ProductSizes.Select(z => new ProductSizeDto
                {
                    Stock = z.Stock,
                    Number = z.Size.Number,
                    ProductId = z.ProductId,
                    Id = z.Id,
                    SizeId = z.SizeId
                }),
                Description = product.Description,
                Price = Context.PriceProducts.Where(u => u.ProductId == product.Id && !u.isDeleted).Select(z => z.Price).FirstOrDefault()
            };
        }
    }
}
