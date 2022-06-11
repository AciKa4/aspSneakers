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
    public class CreatePriceProducValidator : AbstractValidator<PriceProductDto>
    {
        private SneakersDbContext _context;

        public CreatePriceProducValidator(SneakersDbContext context)
        {
            _context = context;

        
            RuleFor(x => x.ProductId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Product id is required.")
                .Must(x => _context.Products.Any(y => y.Id == x)).WithMessage("Provided product id doesn't exists.");

            RuleFor(x => x.Price)
                       .NotNull()
                       .WithMessage("Price is required.")
                       .GreaterThanOrEqualTo(1)
                       .WithMessage("Price can not be less than 0.");

        }
    }
}