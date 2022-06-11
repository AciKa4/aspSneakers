using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Genders;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Genders
{
    public class EfUpdateGenderCommand : EfUseCase, IUpdateGenderCommand
    {
        public EfUpdateGenderCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Update specific gender.";

        public string Description => "";

        public void Execute(GenderDto request)
        {
            var id = request.Id;
            var name = request.Name;

            var gender = Context.Genders.FirstOrDefault(x => x.Id == id);

            if (gender == null)
            {
                throw new EntityNotFoundException(nameof(Gender), id);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullOrEmptyException(nameof(gender.Name));
            }

            gender.Name = name;
            gender.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
