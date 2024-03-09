using FluentValidation;
using FORCEGET.Application.Common.Models;

namespace FORCEGET.Application.Offers.Commands.Create;

public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
{
    public CreateOfferCommandValidator()
    {
        RuleFor(c => c.ModeType).NotNull()
            .WithName(GlobalPropertyDisplayName.ModeType);
        RuleFor(c => c.MovementType).NotNull()
            .WithName(GlobalPropertyDisplayName.MovementType);
        RuleFor(c => c.IncotermsType).NotNull()
            .WithName(GlobalPropertyDisplayName.IncotermsType);
        RuleFor(c => c.PackageType).NotNull()
            .WithName(GlobalPropertyDisplayName.PackageType);
        RuleFor(c => c.Unit1Type).NotNull()
            .WithName(GlobalPropertyDisplayName.Unit1Type);
        RuleFor(c => c.Unit2Type).NotNull()
            .WithName(GlobalPropertyDisplayName.Unit2Type);
        RuleFor(c => c.CurrencyType).NotNull()
            .WithName(GlobalPropertyDisplayName.CurrencyType);
        RuleFor(c => c.CountryId).NotNull()
            .WithName(GlobalPropertyDisplayName.CountryId);
        RuleFor(c => c.CityId).NotNull()
            .WithName(GlobalPropertyDisplayName.CityId);
    }
}