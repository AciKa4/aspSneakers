using AspSneakers.Application.UseCases.Commands.Genders;
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

namespace AspSneakers.Implementation.UseCases.Commands.Genders
{
    public class EfCreateGenderCommand : EfUseCase, ICreateGenderCommand
    {
        private CreateGenderValidator _validator;

        public EfCreateGenderCommand(SneakersDbContext context, CreateGenderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Create gender.";

        public string Description => "";

        public void Execute(GenderDto request)
        {
            _validator.ValidateAndThrow(request);

            var gender = new Gender
            {
                Id = request.Id,
                Name = request.Name
            };

            Context.Genders.Add(gender);
            Context.SaveChanges();
        }
    }
}
