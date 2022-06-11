using AspSneakers.Application.UseCases.Commands.Sizes;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using AspSneakers.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.SIzes
{
    public class EfCreateSizeCommand : EfUseCase, ICreateSizeCommand
    {
        private CreateSizeValidator _validator;
        public EfCreateSizeCommand(SneakersDbContext context, CreateSizeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Create size for products.";

        public string Description => "";

        public void Execute(SizeDto request)
        {
            _validator.ValidateAndThrow(request);

            var size = new Size
            {
               Number = request.Number
            };

            Context.Sizes.Add(size);
            Context.SaveChanges();
        }
    }
}
