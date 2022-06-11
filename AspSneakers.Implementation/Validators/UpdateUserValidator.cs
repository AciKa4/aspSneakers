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
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        private SneakersDbContext _context;
        public UpdateUserValidator(SneakersDbContext context)
        {
            _context = context;


            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not in good format.")
                .Must(x => !_context.Users.Any(u => u.Email == x)).WithMessage("Email:  {PropertyValue} already in use.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Minimal number of characters is 3.")
                .MaximumLength(12).WithMessage("Max number of characters is 12.")
                .Matches("^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$")
                .WithMessage("Username is not in good format.")
                .Must(x => !_context.Users.Any(u => u.Username == x)).WithMessage("Username: {PropertyValue} already exists.")
                .When(x => !string.IsNullOrWhiteSpace(x.Username));

            var imePrezimeRegex = @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";

            RuleFor(x => x.FirstName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Firstname is required.")
                .Matches(imePrezimeRegex).WithMessage("Firstname is not in good format.")
                .When(x => !string.IsNullOrWhiteSpace(x.FirstName));

            RuleFor(x => x.LastName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Lastname is required.")
                .Matches(imePrezimeRegex).WithMessage("Lastname is not in good format.")
                .When(x => !string.IsNullOrWhiteSpace(x.LastName));

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Password must have minimal 8 characters,one uppercase, one lowercase letter, number and special character.")
                .When(x => !string.IsNullOrWhiteSpace(x.Password));

        }
    }
}
