using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Products;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Products
{
    public class EfDeleteProductCommand : EfUseCase, IDeleteProductCommand
    {
        public EfDeleteProductCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 33;

        public string Name => "Soft delete for product.";

        public string Description => "";

        public void Execute(int request)
        {
            var product = Context.Products.FirstOrDefault(x => x.Id == request);

            if (product == null)
            {
                throw new EntityNotFoundException(nameof(Product), request);
            }

            product.isDeleted = true;
            product.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
