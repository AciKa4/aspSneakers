using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using AspSneakers.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Products
{
    public class EfCreatePriceProductCommand : EfUseCase, ICreatePriceProductCommand
    {
        private CreatePriceProducValidator _validator;
        public EfCreatePriceProductCommand(SneakersDbContext context, CreatePriceProducValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 26;

        public string Name => "Create price for product.";

        public string Description => "";

        public void Execute(PriceProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var productPrice = new PriceProduct
            {
                ProductId = request.ProductId,
                Price = request.Price,
            };

            Context.PriceProducts.Add(productPrice);
            Context.SaveChanges();
        }
    }
}
