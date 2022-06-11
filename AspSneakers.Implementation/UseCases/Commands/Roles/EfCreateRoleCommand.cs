using AspSneakers.Application.UseCases.Commands.Roles;
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

namespace AspSneakers.Implementation.UseCases.Commands.Roles
{
    public class EfCreateRoleCommand : EfUseCase, ICreateRoleCommand
    {
        private CreateRoleValidator _validator;
        public EfCreateRoleCommand(SneakersDbContext context, CreateRoleValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Create new role.";

        public string Description => "";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = new Role
            {
                Id = request.Id,
                Name = request.Name
            };

            Context.Roles.Add(role);
            Context.SaveChanges();
        }
    }
}
