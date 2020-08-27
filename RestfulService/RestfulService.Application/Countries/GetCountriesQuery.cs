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
    public class GetCountriesQuery : IRequest<List<Country>>
    {
    }

    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<Country>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetCountriesQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Country>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Countries.ToListAsync();
        }
    }
}
