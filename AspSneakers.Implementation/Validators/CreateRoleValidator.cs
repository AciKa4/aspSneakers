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
    public class CreateRoleValidator : AbstractValidator<RoleDto>
    {
        private SneakersDbContext _context;

        public CreateRoleValidator(SneakersDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Role name is required.")
                .MinimumLength(4).WithMessage("Role name must contain atleast 4 characters.")
                .Must(name => !context.Roles.Any(y => y.Name == name)).WithMessage("Role: {PropertyValue} already exists.");
        }
    }
}
