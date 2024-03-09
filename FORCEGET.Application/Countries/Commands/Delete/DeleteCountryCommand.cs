using FORCEGET.Application.Common.Exceptions;
using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Application.Countries.Commands.Delete;

public class DeleteCountryCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteCountryCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            Country? country = await _context.Countries
                .FirstOrDefaultAsync(c => c.Id == request.Id,cancellationToken);

            if (country == null)
            {
                throw new BadRequestException("Country not found.");
            }
            
            List<City> cities = await _context.Cities
                .Where(c => c.CountryId == request.Id)
                .ToListAsync(cancellationToken);
            _context.Cities.RemoveRange(cities);
            await _context.SaveChangesAsync(cancellationToken);

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value,"Success");
        }
    }
}