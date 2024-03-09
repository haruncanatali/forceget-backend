using FORCEGET.Application.CommonValues.Queries.Dtos;

namespace FORCEGET.Application.CommonValues.Queries.GetCommonValues;

public class GetCommonValuesVm
{
    public Dictionary<string, List<BoxDto>> Enums { get; set; }
    public List<CountryDto> Countries { get; set; }
}