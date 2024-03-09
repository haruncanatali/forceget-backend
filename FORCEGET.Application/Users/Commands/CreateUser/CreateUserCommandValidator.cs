using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithName(GlobalPropertyDisplayName.FirstName);
            RuleFor(x => x.Surname).NotEmpty().WithName(GlobalPropertyDisplayName.Surname);
            RuleFor(x => x.Email).EmailAddress().WithName(GlobalPropertyDisplayName.Email);
            RuleFor(c => c.Password).NotEmpty().WithName(GlobalPropertyDisplayName.Password);
        }
    }
}