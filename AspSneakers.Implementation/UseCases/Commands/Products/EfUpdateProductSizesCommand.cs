using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Products
{
    public class EfUpdateProductSizesCommand : EfUseCase, IUpdateProductSizesCommand
    {
        public EfUpdateProductSizesCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 29;

        public string Name => "Update size for product.";

        public string Description => "";

        public void Execute(ProductSizeDto request)
        {
     
            var productSize = Context.ProductSizes.FirstOrDefault(x => x.ProductId == request.ProductId && x.SizeId == request.SizeId);

            if (productSize == null)
            {
                throw new EntityNotFoundException(nameof(ProductSize), request.Id);
            }

            if(request.Stock < 0)
            {
                throw new InvalidOperationException();
            }

            productSize.Stock = request.Stock;

            Context.SaveChanges();
        }
    }
}
