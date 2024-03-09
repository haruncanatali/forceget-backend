using AutoMapper;
using AutoMapper.QueryableExtensions;
using FORCEGET.Application.Common.Helpers;
using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Application.Offers.Queries.Dtos;
using FORCEGET.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Application.Offers.Queries.GetOffers;

public class GetOffersQueryHandler : IRequestHandler<GetOffersQuery ,BaseResponseModel<GetOffersVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetOffersQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetOffersVm>> Handle(GetOffersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Offer> offerDb = _context.Offers
            .Include(c => c.Country)
            .Include(c => c.City);

        int totalCount = offerDb.Count();
        
        List<OfferDto> offerList = await offerDb
            .ProjectTo<OfferDto>(_mapper.ConfigurationProvider)
            .PagingListAsync(request.Page, request.PageSize, cancellationToken);

        return BaseResponseModel<GetOffersVm>.Success(new GetOffersVm
        {   
            Offers = offerList,
            Count = offerList.Count,
            Total = totalCount,
            PageSize = request.PageSize,
            Page = request.Page
        }, "Success");
    }
}