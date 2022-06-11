using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Products
{
    public class EfDeletePriceProductCommand : EfUseCase, IDeletePriceProductCommand
    {
        public EfDeletePriceProductCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Delete price for product.";

        public string Description => "";

        public void Execute(PriceProductDto request)
        {
            var product = Context.Products.Include(x => x.ProductPrices)
                .FirstOrDefault(x => x.Id == request.ProductId);


            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request.ProductId);
            }
            if (!product.ProductPrices.Any())
            {
                throw new UseCaseConflictException("Selected product doesn't have any price.");
            }

            var productPrice = Context.PriceProducts.OrderBy(x => x.CreatedAt)
                .FirstOrDefault(x => x.ProductId == request.ProductId && !x.isDeleted);

            productPrice.isDeleted = true;
            productPrice.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
