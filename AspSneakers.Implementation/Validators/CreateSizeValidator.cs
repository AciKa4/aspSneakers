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
    public class CreateSizeValidator : AbstractValidator<SizeDto>
    {
        private SneakersDbContext _context;

        public CreateSizeValidator(SneakersDbContext context)
        {
            _context = context;

            RuleFor(x => x.Number)
               .NotNull().WithMessage("Size number is required.")
               .GreaterThanOrEqualTo(25).WithMessage("Size number must be greater or equal to 25.")
               .LessThanOrEqualTo(55).WithMessage("Size number must be less or equal to 55.")
               .Must(x => !_context.Sizes.Any(y => y.Number == x)).WithMessage("Number already exists.");
        }
    }
}