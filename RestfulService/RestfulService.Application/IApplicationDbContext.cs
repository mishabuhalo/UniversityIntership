using Microsoft.EntityFrameworkCore;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestfulService.Application
{
    public interface IApplicationDbContext
    {
         DbSet<City> Cities { get; set; }
         DbSet<Country> Countries { get; set; }

    }
}
