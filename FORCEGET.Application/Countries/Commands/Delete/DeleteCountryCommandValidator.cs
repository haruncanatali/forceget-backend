using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Countries.Commands.Delete;

public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
{
    public DeleteCountryCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithName(GlobalPropertyDisplayName.CountryId);
    }
}