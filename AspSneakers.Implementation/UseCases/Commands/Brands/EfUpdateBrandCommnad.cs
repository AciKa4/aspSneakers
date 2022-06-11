using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Brands;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Brands
{
    public class EfUpdateBrandCommnad : EfUseCase, IUpdateBrandCommand
    {
        public EfUpdateBrandCommnad(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Update specific brand.";

        public string Description => "";

        public void Execute(BrandDto request)
        {
            var id = request.Id;
            var name = request.Name;
            var brand = Context.Brands.FirstOrDefault(x => x.Id == id);

            if(brand == null)
            {
                throw new EntityNotFoundException(nameof(Brand), id);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullOrEmptyException(nameof(brand.Name));
            }

            brand.UpdatedAt = DateTime.UtcNow;
            brand.Name = name;
            Context.SaveChanges();


        }
    }
}
