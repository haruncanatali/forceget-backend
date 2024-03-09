using FORCEGET.Domain.Base;

namespace FORCEGET.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }

    public long CountryId { get; set; }

    public Country Country { get; set; }
    public List<Offer> Offers { get; set; }
}