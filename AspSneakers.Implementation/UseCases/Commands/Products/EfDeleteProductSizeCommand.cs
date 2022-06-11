using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using AspSneakers.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Products
{
    public class EfDeleteProductSizeCommand : EfUseCase, IDeleteProductSizeCommand
    {
        private readonly UpdateUserValidator _validator;
        public EfDeleteProductSizeCommand(SneakersDbContext context, UpdateUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 30;

        public string Name => "Delete specific size for product.";

        public string Description => "";

        public void Execute(int request)
        {
            var productSize = Context.ProductSizes.FirstOrDefault(x => x.Id == request);

            if (productSize == null)
            {
                throw new EntityNotFoundException(nameof(ProductSize), request);
            }

            Context.ProductSizes.Remove(productSize);
            Context.SaveChanges();
        }
    }
}
