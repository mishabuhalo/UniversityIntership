using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Cities.Queries
{
    public class GetCityByIdQuery:IRequest<City>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, City>
    {
        private readonly IApplicationDbContext _context;
        public GetCityByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var cityAA = await _context.Cities.Include(x => x.Country).Where(city => city.Id == request.Id).FirstOrDefaultAsync();
            return cityAA;
        }
    }
}
