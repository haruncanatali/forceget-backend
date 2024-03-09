using FORCEGET.Application.Common.Models;
using FORCEGET.Application.Offers.Queries.Dtos;

namespace FORCEGET.Application.Offers.Queries.GetOffers;

public class GetOffersVm : PaginatedData
{
    public List<OfferDto> Offers { get; set; }
    public int Count { get; set; }
}