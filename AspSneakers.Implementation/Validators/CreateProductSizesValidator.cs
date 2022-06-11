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
    public class CreateProductSizesValidator : AbstractValidator<ProductSizeDto>
    {
        private SneakersDbContext _context;

        public CreateProductSizesValidator(SneakersDbContext context)
        {
            _context = context;


            RuleFor(x => x.SizeId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Product id is required.")
                .Must(x => _context.Sizes.Any(y => y.Id == x)).WithMessage("Provided size id doesn't exists.");

            RuleFor(x => x.ProductId).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Product id is required.")
                .Must(x => _context.Products.Any(y => y.Id == x)).WithMessage("Provided products id doesn't exists.");

            RuleFor(x => x).Must(x => !_context.ProductSizes.Any(y => y.ProductId == x.ProductId && y.SizeId == x.SizeId))
                .WithMessage("Provided size for product already exists.");

            RuleFor(x => x.Stock)
                       .NotNull()
                       .WithMessage("Stock is required.")
                       .GreaterThanOrEqualTo(0)
                       .WithMessage("Stock can not be less than 0.");

        }
    }
}
