using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestfulService.Application.Countries;
using RestfulService.Application.Countries.Commands;
using RestfulService.Domain.Entities;
using RestfulService.Infrastructure.Persistance;

namespace RestfulService.Controlers
{
    public class CountriesController : ControlerBase
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> List()
        {
            return View(await Mediator.Send(new GetCountriesQuery()));
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View(await Mediator.Send(new GetCountryByIdQuery { ListId = id.Value }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Country country)
        {
            var id = await Mediator.Send(new CreateCountryCommand { Name = country.Name });

            return Redirect($"/Countries/List/{id}");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            return View(await Mediator.Send(new GetCountryByIdQuery { ListId = id.Value }));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Country country)
        {
            await Mediator.Send(new EditCountryCommand { Id = country.Id, Name = country.Name });
            return Redirect("/Countries/List");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            await Mediator.Send(new DeleteCountryCommand { Id = id.Value });
            return Redirect("/Countries/List");
        }
    }
}

