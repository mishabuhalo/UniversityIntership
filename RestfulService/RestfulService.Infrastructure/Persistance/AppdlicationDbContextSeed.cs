using Microsoft.EntityFrameworkCore.Internal;
using RestfulService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestfulService.Infrastructure.Persistance
{
    public static class AppdlicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Countries.Any())
            {
                context.Countries.Add(new Country
                {
                    Name = "Ukraine",
                    Cities =
                    {
                        new City { Name = "Kyiv", isCapital= true, Population= 1337},
                        new City { Name = "Rivne", isCapital= false, Population= 10000}
                    }
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
