using Microsoft.EntityFrameworkCore;
using RestfulService.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Application
{
    public interface IApplicationDbContext
    {
         DbSet<City> Cities { get; set; }
         DbSet<Country> Countries { get; set; }
         Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
