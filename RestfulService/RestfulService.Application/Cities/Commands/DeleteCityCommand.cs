using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Cities.Commands
{
    public class DeleteCityCommand:IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteCityCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cities.FindAsync(request.Id);

            if(entity!=null)
            {
                _context.Cities.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;

        }
    }
}
