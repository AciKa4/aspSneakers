using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.Validators
{
    public  class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        private SneakersDbContext _context;

        public CreateProductValidator(SneakersDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Product name is required.")
             .MinimumLength(3).WithMessage("Product name must contain atleast 3 characters.")
             .Must(name => !context.Products.Any(y => y.Name == name)).WithMessage("Product: {PropertyValue} already exists.");


            RuleFor(x => x.BrandId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Brand id is required.")
                .Must(x => _context.Brands.Any(y => y.Id == x)).WithMessage("Provided brand id doesn't exists.");

            RuleFor(x => x.GenderId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Gender id is required.")
                .Must(x => _context.Genders.Any(y => y.Id == x)).WithMessage("Provided gender id doesn't exists.");

            RuleFor(x => x.Categories).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Categories are required.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Duplicates are not allowed [categories].")
                .Must(x => _context.Categories.Any(y => x.Contains(y.Id))).WithMessage("Some of category id doesn't exists.");

            RuleFor(x => x.Description).Cascade(CascadeMode.Stop)
             .NotEmpty().WithMessage("Description name is required.")
             .MinimumLength(5).WithMessage("Produt description must contain atleast 5 characters.");

        }
    }
}
