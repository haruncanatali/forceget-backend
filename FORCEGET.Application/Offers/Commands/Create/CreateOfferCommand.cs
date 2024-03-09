using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Entities;
using FORCEGET.Domain.Enums;
using MediatR;

namespace FORCEGET.Application.Offers.Commands.Create;

public class CreateOfferCommand : IRequest<BaseResponseModel<Unit>>
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
    
    public class Handler : IRequestHandler<CreateOfferCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            await _context.Offers.AddAsync(new Offer
            {
                ModeType = request.ModeType,
                MovementType = request.MovementType,
                IncotermsType = request.IncotermsType,
                PackageType = request.PackageType,
                Unit1Type = request.Unit1Type,
                Unit2Type = request.Unit2Type,
                CurrencyType = request.CurrencyType,
                CountryId = request.CountryId,
                CityId = request.CityId
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Offers added successfully.");
        }
    }
}