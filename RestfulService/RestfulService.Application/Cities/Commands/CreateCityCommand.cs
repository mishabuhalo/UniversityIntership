using MediatR;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Cities.Commands
{
    public class CreateCityCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
        public bool IsCapital { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = new City {
                Name = request.Name,
                Population = request.Population,
                isCapital = request.IsCapital,
                CountryId = request.CountryId,
            };
            _context.Cities.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
