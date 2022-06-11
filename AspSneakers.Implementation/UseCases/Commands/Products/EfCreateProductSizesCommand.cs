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
    public class EfCreateProductSizesCommand : EfUseCase, ICreateProductSizesCommand
    {
        private CreateProductSizesValidator _validator;
        public EfCreateProductSizesCommand(SneakersDbContext context, CreateProductSizesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 28;

        public string Name => "Create sizes for product.";

        public string Description => "";

        public void Execute(ProductSizeDto request)
        {
            _validator.ValidateAndThrow(request);

        
            var productPrice = new ProductSize
            {
                SizeId = request.SizeId,
                ProductId = request.ProductId,
                Stock = request.Stock
            };

            Context.ProductSizes.Add(productPrice);
            Context.SaveChanges();
        }
    }
}
