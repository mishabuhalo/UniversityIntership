using Microsoft.EntityFrameworkCore.Internal;
using RestfulService.Domain.Entities;
using System.Linq;

namespace RestfulService.Infrastructure.Persistance
{
    public static class AppdlicationDbContextSeed
    {
        public static  void SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (context.Countries.Count() == 0)
            {
                context.Countries.Add(new Country
                {
                    Name = "Ukraine",
                    Cities = new System.Collections.Generic.List<City>
                    {
                        new City { Name = "Kyiv", isCapital= true, Population= 1337},
                        new City { Name = "Rivne", isCapital= false, Population= 10000}
                    }
                });

                context.SaveChanges();
            }
        }
    }
}
