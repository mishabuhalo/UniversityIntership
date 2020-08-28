using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application.Countries.Commands
{
    public class EditCountryCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EditCountryCommandHandler : IRequestHandler<EditCountryCommand>
    {
        private readonly IApplicationDbContext _context;

        public EditCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(EditCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries.FindAsync(request.Id);

            if(entity!= null)
            {
                entity.Name = request.Name;

                await _context.SaveChangesAsync(cancellationToken);

            }

            return Unit.Value;
        }
    }
}
