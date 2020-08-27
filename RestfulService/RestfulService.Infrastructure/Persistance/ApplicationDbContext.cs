using Microsoft.EntityFrameworkCore;
using RestfulService.Application;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
