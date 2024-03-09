using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Auth.Queries.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithName(GlobalPropertyDisplayName.Password);
            RuleFor(x => x.Email).NotEmpty().WithName(GlobalPropertyDisplayName.Email);
        }
    }
}
