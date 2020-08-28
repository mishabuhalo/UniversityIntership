using Microsoft.EntityFrameworkCore;
using RestfulService.Application;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestfulService.Infrastructure.Persistance
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
             //Database.EnsureCreated();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
