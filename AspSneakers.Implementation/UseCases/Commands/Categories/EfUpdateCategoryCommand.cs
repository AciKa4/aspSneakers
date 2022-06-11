using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases;
using AspSneakers.Application.UseCases.Commands.Categories;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Categories
{
    public class EfUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        public EfUpdateCategoryCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Update specific category.";

        public string Description => "";

        public void Execute(CategoryDto request)
        {
            var id = request.Id;
            var name = request.Name;

            var category = Context.Categories.FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                throw new EntityNotFoundException(nameof(Category), id);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullOrEmptyException(nameof(category.Name));
            }

            category.Name = name;
            category.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();

        }
    }
}
