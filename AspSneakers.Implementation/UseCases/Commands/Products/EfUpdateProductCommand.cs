using AspSneakers.Application.Exceptions;
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
    public class EfUpdateProductCommand : EfUseCase, IUpdateProductCommand
    {
        private UpdateProductValidator _validator;
        public EfUpdateProductCommand(SneakersDbContext context, UpdateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => "Update product.";

        public string Description => "";

        public void Execute(UpdateProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var name = request.Name;


            var product = Context.Products.FirstOrDefault(x => x.Id == request.Id);


            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request.Id);
            }


            if (!string.IsNullOrEmpty(request.Name))
                product.Name = request.Name;

            if (request.GenderId != null)
                product.GenderId = request.GenderId.Value;

            if (request.BrandId != null)
                product.BrandId = request.BrandId.Value;

            if (!string.IsNullOrEmpty(request.Description))
                product.Description = request.Description;

            if (request.Categories.Count() > 0)
            {
                var categories = Context.ProductCategories.Where(x => x.ProductId == request.Id);

                if (categories != null)
                {
                    Context.RemoveRange(categories);

                }

                product.Categories = request.Categories.Select(x => new ProductCategory
                {
                    CategoryId = x
                }).ToList();
            }

            product.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
