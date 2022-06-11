using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Roles;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Roles
{
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        public EfUpdateRoleCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Update specific role.";

        public string Description => "";

        public void Execute(RoleDto request)
        {
            var id = request.Id;
            var name = request.Name;

            var role = Context.Roles.FirstOrDefault(x => x.Id == id);

            if (role == null)
            {
                throw new EntityNotFoundException(nameof(Category), id);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new NullOrEmptyException(nameof(role.Name));
            }

            role.Name = name;
            role.UpdatedAt = DateTime.UtcNow;

            Context.SaveChanges();
        }
    }
}
