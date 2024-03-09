using FORCEGET.Domain.Base;
using FORCEGET.Domain.Enums;

namespace FORCEGET.Domain.Entities;

public class Offer : BaseEntity
{
    public ModeType ModeType { get; set; }
    public MovementType MovementType { get; set; }
    public IncotermsType IncotermsType { get; set; }
    public PackageType PackageType { get; set; }
    public Unit1Type Unit1Type { get; set; }
    public Unit2Type Unit2Type { get; set; }
    public CurrencyType CurrencyType { get; set; }
    public long CountryId { get; set; }
    public long CityId { get; set; }

    public Country Country { get; set; }
    public City City { get; set; }
}