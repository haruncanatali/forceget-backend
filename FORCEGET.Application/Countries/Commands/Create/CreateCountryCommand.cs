using FORCEGET.Application.Common.Interfaces;
using FORCEGET.Application.Common.Models;
using FORCEGET.Domain.Entities;
using MediatR;

namespace FORCEGET.Application.Countries.Commands.Create;

public class CreateCountryCommand : IRequest<BaseResponseModel<Unit>>
{
    public string Name { get; set; }
    
    public class Handler : IRequestHandler<CreateCountryCommand, BaseResponseModel<Unit>>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponseModel<Unit>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            await _context.Countries.AddAsync(new Country
            {
                Name = request.Name
            });

            await _context.SaveChangesAsync(cancellationToken);
            
            return BaseResponseModel<Unit>.Success(Unit.Value, "Success");
        }
    }
}