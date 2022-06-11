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
    public class CreateBrandValidator : AbstractValidator<BrandDto>
    {
        private SneakersDbContext _context;

        public CreateBrandValidator(SneakersDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Brand name is required.")
                .MinimumLength(3).WithMessage("Brand name must contain atleast 3 characters.")
                .Must(name => !_context.Brands.Any(y => y.Name == name)).WithMessage("Brand: {PropertyValue} already exists.");
        }
    }
}
