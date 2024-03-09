using AutoMapper;
using FORCEGET.Application.Common.Mappings;
using FORCEGET.Domain.Entities;

namespace FORCEGET.Application.CommonValues.Queries.Dtos;

public class CountryDto : IMapFrom<Country>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<CityDto> Cities { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Country, CountryDto>()
            .ForMember(dest => dest.Cities, opt =>
                opt.MapFrom(c => c.Cities));
    }
}