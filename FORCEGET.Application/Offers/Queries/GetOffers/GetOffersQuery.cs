using FORCEGET.Application.Common.Models;
using MediatR;

namespace FORCEGET.Application.Offers.Queries.GetOffers;

public class GetOffersQuery : PaginatedQuery, IRequest<BaseResponseModel<GetOffersVm>>
{
    
}