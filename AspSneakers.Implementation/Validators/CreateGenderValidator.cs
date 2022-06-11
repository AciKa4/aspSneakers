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
    public class CreateGenderValidator : AbstractValidator<GenderDto>
    {
        private SneakersDbContext _context;

        public CreateGenderValidator(SneakersDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Gender name is required.")
                .MinimumLength(3).WithMessage("Brand name must contain atleast 3 characters.")
                .Must(name => !context.Genders.Any(y => y.Name == name)).WithMessage("Gender: {PropertyValue} already exists.");
        }
    }
}
