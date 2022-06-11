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
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        private SneakersDbContext _context;

        public CreateCategoryValidator(SneakersDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category name is required.")
                .MinimumLength(2).WithMessage("Minimal character number is 2.")
                .Must(name => !context.Categories.Any(y => y.Name == name && !y.isDeleted)).WithMessage("Category already exists.");


        }
    }
}
