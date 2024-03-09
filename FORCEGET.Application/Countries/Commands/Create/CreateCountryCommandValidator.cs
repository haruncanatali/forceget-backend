using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Countries.Commands.Create;

public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.CountryName);
    }
}