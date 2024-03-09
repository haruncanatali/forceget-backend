using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Entities;
using MediatR;

namespace FORCEGET.Application.Cities.Commands.Create;

public class CreateCityCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    public long CountryId { get; set; }
    
    public class Handler : IRequestHandler<CreateCityCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            await _context.Cities.AddAsync(new City
            {
                Name = request.Name,
                CountryId = request.CountryId
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Success");
        }
    }
}