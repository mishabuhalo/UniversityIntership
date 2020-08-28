using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Cities
{
    public class ListCitiesQuery : IRequest<List<City>>
    {
    }

    public class ListCitiesQueryHandler : IRequestHandler<ListCitiesQuery, List<City>>
    {
        private readonly IApplicationDbContext _context;
        public ListCitiesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<City>> Handle(ListCitiesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cities.Include(x => x.Country).ToListAsync();
        }
    }
}
