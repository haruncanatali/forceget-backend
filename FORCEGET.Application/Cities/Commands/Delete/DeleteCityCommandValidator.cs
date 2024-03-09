using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Cities.Commands.Delete;

public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
{
    public DeleteCityCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.CityId);
    }
}