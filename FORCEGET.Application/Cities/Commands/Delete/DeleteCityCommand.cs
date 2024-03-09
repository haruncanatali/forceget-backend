using FORCEGET.Application.Common.Exceptions;
using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FORCEGET.Application.Cities.Commands.Delete;

public class DeleteCityCommand : IRequest<BaseResponseModel<Unit>>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteCityCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City? city = await _context.Cities
                .FirstOrDefaultAsync(c => c.Id == request.Id,cancellationToken);

            if (city == null)
            {
                throw new BadRequestException("City not found.");
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Success");
        }
    }
}