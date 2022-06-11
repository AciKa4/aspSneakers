using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Brands;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Brands
{
    public class EfDeleteBrandCommand : EfUseCase, IDeleteBrandCommand
    {
        public EfDeleteBrandCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Delete specific brand.";

        public string Description => "";

        public void Execute(int id)
        {
            var brand = Context.Brands.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

            if (brand == null)
            {
                throw new EntityNotFoundException(nameof(Brand), id);
            }

            if (brand.Products.Any())
            {
                throw new UseCaseConflictException("Can not delete brand because it is link to products.");
            }

            brand.isDeleted = true;
            brand.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
