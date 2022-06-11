using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.Application.UseCases.Queries.Categories;
using AspSneakers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Queries.Ef.Category
{
    public class EfFindCategoryQuery : EfUseCase, IFindCategoryQuery
    {
        public EfFindCategoryQuery(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Find specific category.";

        public string Description => "";
        public CategoryDto Execute(int search)
        {
            var category = Context.Categories.FirstOrDefault(x => x.Id == search && !x.isDeleted);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), search);
            }

            return new CategoryDto
            {
               Id = category.Id,
               Name = category.Name
            };
        }
    }
}
