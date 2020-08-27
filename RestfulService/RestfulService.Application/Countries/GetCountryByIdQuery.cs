using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Countries
{
    public class GetCountryByIdQuery: IRequest<Country>
    {
        public int ListId { get; set; }
    }

    public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly IApplicationDbContext _context;
        public GetCountryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
             return await _context.Countries.Where(country => country.Id == request.ListId).FirstOrDefaultAsync();
        }
    }
}
