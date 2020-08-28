using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Cities.Commands
{
    public class EditCityCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
        public bool IsCapital { get; set; }
    }

    public class EditCityCommandHandler : IRequestHandler<EditCityCommand>
    {
        private readonly IApplicationDbContext _context;
        public EditCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(EditCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cities.FindAsync(request.Id);
            if (entity != null)
            {
                entity.Name = request.Name;
                entity.Population = request.Population;
                entity.isCapital = request.IsCapital;
                entity.CountryId = request.CountryId;

                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
