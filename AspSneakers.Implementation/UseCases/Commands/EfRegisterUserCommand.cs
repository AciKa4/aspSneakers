using AspSneakers.Application.Emails;
using AspSneakers.Application.UseCases.Commands;
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

namespace AspSneakers.Implementation.UseCases.Commands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(SneakersDbContext context, RegisterUserValidator validator, IEmailSender sender) 
            : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var hashValue = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                RoleId = 2,
                Address = request.Address,
                Email = request.Email,
                Password = hashValue,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            Context.Users.Add(user);
            Context.SaveChanges();

            

            _sender.Send(new EmailDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.Username + "\n Please activate your account."
            });
        }

        public int Id => 1;

        public string Name => "User reigstration";

        public string Description => "";
    }
}
