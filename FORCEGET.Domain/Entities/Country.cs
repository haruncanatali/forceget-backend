using FORCEGET.Domain.Base;

namespace FORCEGET.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }

    public List<City> Cities { get; set; }
    public List<Offer> Offers { get; set; }
}