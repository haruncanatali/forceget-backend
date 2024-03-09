using AutoMapper;
using AutoMapper.QueryableExtensions;
using FORCEGET.Application.Common.Helpers;
using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Application.CommonValues.Queries.Dtos;
using FORCEGET.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Application.CommonValues.Queries.GetCommonValues;

public class GetCommonValuesQueryHandler : IRequestHandler<GetCommonValuesQuery, BaseResponseModel<GetCommonValuesVm>>
{
    private readonly IApplicationContext _context;
    private readonly IMapper _mapper;

    public GetCommonValuesQueryHandler(IApplicationContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseModel<GetCommonValuesVm>> Handle(GetCommonValuesQuery request, CancellationToken cancellationToken)
    {
        GetCommonValuesVm result = new GetCommonValuesVm();
        
        Dictionary<string, List<BoxDto>> enums = new Dictionary<string, List<BoxDto>>();
        
        enums["CurrencyTypes"] = Enum.GetValues<CurrencyType>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();
        
        enums["IncotermsTypes"] = Enum.GetValues<IncotermsType>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();
        
        enums["ModeTypes"] = Enum.GetValues<ModeType>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();
        
        enums["MovementTypes"] = Enum.GetValues<MovementType>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();
        
        enums["PackageTypes"] = Enum.GetValues<PackageType>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();
        
        enums["Unit1Types"] = Enum.GetValues<Unit1Type>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();
        
        enums["Unit2Types"] = Enum.GetValues<Unit2Type>().Select(c => new BoxDto
        {
            Label = c.GetDescription(),
            Value = ((int)c)
        }).ToList();

        result.Enums = enums;
        result.Countries = await _context.Countries
            .Include(c => c.Cities)
            .ProjectTo<CountryDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return BaseResponseModel<GetCommonValuesVm>.Success(result,"Success");
    }
}