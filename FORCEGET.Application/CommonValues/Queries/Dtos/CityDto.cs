using AutoMapper;
using FORCEGET.Application.Common.Mappings;
using FORCEGET.Domain.Entities;

namespace FORCEGET.Application.CommonValues.Queries.Dtos;

public class CityDto : IMapFrom<City>
{
    public long Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<City, CityDto>();
    }
}