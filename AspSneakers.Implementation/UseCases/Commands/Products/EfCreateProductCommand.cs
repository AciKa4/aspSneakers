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
    public class EfCreateProductCommand : EfUseCase, ICreateProductCommand
    {
        private CreateProductValidator _validator;
        public EfCreateProductCommand(SneakersDbContext context, CreateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 22;

        public string Name => "Create product.";

        public string Description => "";

        public void Execute(CreateProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var product = new Product
            {
                Name = request.Name,
                BrandId = request.BrandId,
                GenderId = request.GenderId,
                ProductPrices = new List<PriceProduct>
                { 
                    new PriceProduct { Price = request.Price}
                },
                Description = request.Description,
                Categories = request.Categories.Select(x => new ProductCategory
                {
                    CategoryId = x
                }).ToList(),
            };


         
            if(!string.IsNullOrEmpty(request.ImageFileName))
            {
                var image = new Image
                {
                    url = request.ImageFileName
                };

                product.Images.Add(image);
            }

            Context.Products.Add(product);
            Context.SaveChanges();
        }
    }
}
