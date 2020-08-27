using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestfulService.Application.Countries;
using RestfulService.Infrastructure.Persistance;

namespace RestfulService.Controlers
{
    public class DatabaseController : ControlerBase
    {
        private readonly ApplicationDbContext _context;

        public DatabaseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await Mediator.Send(new GetCountriesQuery()));
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await Mediator.Send(new GetCountryByIdQuery { ListId = id }));
        }
    }
}
