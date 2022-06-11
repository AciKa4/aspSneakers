using AspSneakers.Application.UseCases.Commands;
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

namespace AspSneakers.Implementation.UseCases.Commands
{
    public class EfUpdateUserUseCasesCommand : EfUseCase, IUpdateUseCasesCommand
    {
        private UpdateUserUseCasesValidator _validator;

        public EfUpdateUserUseCasesCommand(SneakersDbContext context,UpdateUserUseCasesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Update user use cases.";

        public string Description => "";

        public void Execute(UserUseCasesDto request)
        {
            _validator.ValidateAndThrow(request);

            var useCases = Context.UserUseCases.Where(x => x.UserId == request.UserId);


            Context.RemoveRange(useCases);


            var newCases = request.UseCaseIds.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = request.UserId
            });


            Context.UserUseCases.AddRange(newCases);
            Context.SaveChanges();

        }
    }
}
