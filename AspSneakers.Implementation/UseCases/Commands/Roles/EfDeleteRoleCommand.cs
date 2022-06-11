using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Roles;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Roles
{
    public class EfDeleteRoleCommand : EfUseCase, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 13;
        public string Name => "Delete role.";

        public string Description => "";

        public void Execute(int request)
        {

            var role = Context.Roles.Include(x => x.Users).FirstOrDefault(x => x.Id == request);


            if (role == null)
            {
                throw new EntityNotFoundException(nameof(Role), request);
            }

            if (role.Users.Any())
            {
                throw new UseCaseConflictException("Can not delete role because it is link to users.");
            }

            role.isDeleted = true;
            role.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
