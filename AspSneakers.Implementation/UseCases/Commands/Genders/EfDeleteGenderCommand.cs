using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Genders;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Genders
{
    public class EfDeleteGenderCommand : EfUseCase, IDeleteGenderCommand
    {
        public EfDeleteGenderCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Delete gender.";

        public string Description => "";

        public void Execute(int request)
        {
            var gender = Context.Genders.Include(x => x.Products).FirstOrDefault(x => x.Id == request);


            if (gender == null)
            {
                throw new EntityNotFoundException(nameof(Gender), request);
            }

            if (gender.Products.Any())
            {
                throw new UseCaseConflictException("Can not delete category because it is link to products.");
            }

            gender.isDeleted = true;
            gender.DeletedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
