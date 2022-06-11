using AspSneakers.Application.UseCases.Commands.Brands;
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

namespace AspSneakers.Implementation.UseCases.Commands.Brands
{
    public class EfCreateBrandCommand : EfUseCase, ICreateBrandCommand
    {
        private CreateBrandValidator _validator;
        public EfCreateBrandCommand(SneakersDbContext context, CreateBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Create new brand.";

        public string Description => "Create new brand using EF";

        public void Execute(BrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var brand = new Brand
            {
                Id = request.Id,
                Name = request.Name
            };

            Context.Brands.Add(brand);
            Context.SaveChanges();
        }
    }
}
