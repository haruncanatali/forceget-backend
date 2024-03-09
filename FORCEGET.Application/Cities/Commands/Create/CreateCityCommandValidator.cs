using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Cities.Commands.Create;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty()
            .WithName(GlobalPropertyDisplayName.CityName);
        RuleFor(c => c.CountryId).NotNull()
            .WithName(GlobalPropertyDisplayName.CountryId);
    }
}