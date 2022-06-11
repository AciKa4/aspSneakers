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
    public class UpdateUserUseCasesValidator : AbstractValidator<UserUseCasesDto>
    {
        public UpdateUserUseCasesValidator(SneakersDbContext context)
        {
            RuleFor(x => x.UserId)
                .Must(x => context.Users.Any(y => y.Id == x)).WithMessage("User doesn't exists.");


            RuleFor(x => x.UseCaseIds).NotEmpty()
                .WithMessage("UseCaseIds can not be empty.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique val ues.");
        }
    }
}
