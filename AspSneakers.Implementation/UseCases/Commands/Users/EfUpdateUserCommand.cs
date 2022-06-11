using AspSneakers.Application.Exceptions;
using AspSneakers.Application.UseCases.Commands.Users;
using AspSneakers.Application.UseCases.DTO;
using AspSneakers.DataAccess;
using AspSneakers.Domain;
using AspSneakers.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspSneakers.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly UpdateUserValidator _validator;
        public EfUpdateUserCommand(SneakersDbContext context, UpdateUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Update specific user.";

        public string Description => "";

        public void Execute(UserDto request)
        {
            var id = request.Id;
  
            var user = Context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), id);
            }

            _validator.ValidateAndThrow(request);

            if (!string.IsNullOrEmpty(request.FirstName))
                user.FirstName = request.FirstName;

            if (!string.IsNullOrEmpty(request.LastName))
                user.LastName = request.LastName;

            if (!string.IsNullOrEmpty(request.Address))
                user.Address = request.Address;

            if (!string.IsNullOrEmpty(request.Username))
                user.Username = request.Username;

            if (!string.IsNullOrEmpty(request.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UpdatedAt = DateTime.UtcNow;
            Context.SaveChanges();

        }
    }
}
