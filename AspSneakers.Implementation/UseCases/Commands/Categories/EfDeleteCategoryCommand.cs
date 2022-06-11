using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Categories;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Categories
{
    public class EfDeleteCategoryCommand : EfUseCase, IDeleteCategoryCommand
    {
        public EfDeleteCategoryCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Soft delete category.";

        public string Description => "";

        public void Execute(int request)
        {
            var category = Context.Categories.Include(x => x.Products).FirstOrDefault(x => x.Id == request && !x.isDeleted);


            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            if (category.Products.Any())
            {
                throw new UseCaseConflictException("Can not delete category because it is link to products.");
            }

            category.isDeleted = true;
            category.DeletedAt = DateTime.UtcNow;


            Context.SaveChanges();

        }
    }
}
