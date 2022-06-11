using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Sizes;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.SIzes
{
    public class EfDeleteSizeCommand : EfUseCase, IDeleteSizeCommand
    {
        public EfDeleteSizeCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 24;

        public string Name => "Delete specific size.";

        public string Description => "";

        public void Execute(int request)
        {
            var size = Context.Sizes.Include(x => x.ProductSizes).FirstOrDefault(x => x.Id == request);


            if (size == null)
            {
                throw new EntityNotFoundException(nameof(Role), request);
            }

            if (size.ProductSizes.Any())
            {
                throw new UseCaseConflictException("Can not delete  size because it is link to products.");
            }

            Context.Sizes.Remove(size);
            Context.SaveChanges();
        }
    }
}
