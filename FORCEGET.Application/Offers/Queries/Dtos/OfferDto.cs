using AutoMapper;
using FORCEGET.Application.Common.Helpers;
using FORCEGET.Application.Common.Mappings;
using FORCEGET.Domain.Entities;

namespace FORCEGET.Application.Offers.Queries.Dtos;

public class OfferDto : IMapFrom<Offer>
{
    public long Id { get; set; }
    public string ModeType { get; set; }
    public string MovementType { get; set; }
    public string IncotermsType { get; set; }
    public string PackageType { get; set; }
    public string Unit1Type { get; set; }
    public string Unit2Type { get; set; }
    public string CurrencyType { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Offer, OfferDto>()
            .ForMember(dest => dest.ModeType, opt =>
                opt.MapFrom(c => c.ModeType.GetDescription()))
            .ForMember(dest => dest.MovementType, opt =>
                opt.MapFrom(c => c.MovementType.GetDescription()))
            .ForMember(dest => dest.IncotermsType, opt =>
                opt.MapFrom(c => c.IncotermsType.GetDescription()))
            .ForMember(dest => dest.PackageType, opt =>
                opt.MapFrom(c => c.PackageType.GetDescription()))
            .ForMember(dest => dest.Unit1Type, opt =>
                opt.MapFrom(c => c.Unit1Type.GetDescription()))
            .ForMember(dest => dest.Unit2Type, opt =>
                opt.MapFrom(c => c.Unit2Type.GetDescription()))
            .ForMember(dest => dest.CurrencyType, opt =>
                opt.MapFrom(c => c.CurrencyType.GetDescription()))
            .ForMember(dest => dest.Country, opt =>
                opt.MapFrom(c => c.Country.Name))
            .ForMember(dest => dest.City, opt =>
                opt.MapFrom(c => c.City.Name));

    }
}