using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Users;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(SneakersDbContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Delete user.";

        public string Description => "";

        public void Execute(int request)
        {
            var user = Context.Users.Include(x => x.Orders).FirstOrDefault(x => x.Id == request);


            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), request);
            }

            if (user.Orders.Any())
            {
                throw new UseCaseConflictException("Can not delete user, because user has orders.");
            }

            user.isDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
