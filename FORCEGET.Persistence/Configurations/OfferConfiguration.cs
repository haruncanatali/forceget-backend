using FORCEGET.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FORCEGET.Persistence.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.Property(c => c.ModeType).IsRequired();
        builder.Property(c => c.MovementType).IsRequired();
        builder.Property(c => c.IncotermsType).IsRequired();
        builder.Property(c => c.PackageType).IsRequired();
        builder.Property(c => c.Unit1Type).IsRequired();
        builder.Property(c => c.Unit2Type).IsRequired();
        builder.Property(c => c.CurrencyType).IsRequired();
        builder.Property(c => c.CountryId).IsRequired();
        builder.Property(c => c.CityId).IsRequired();
    }
}