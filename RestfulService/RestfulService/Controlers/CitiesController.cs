using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestfulService.Application.Cities;
using RestfulService.Application.Cities.Commands;
using RestfulService.Application.Cities.Queries;
using RestfulService.Application.Countries;
using RestfulService.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestfulService.Controlers
{
    public class CitiesController : ControlerBase
    {
        public async Task<IActionResult> List()
        {
            return View(await Mediator.Send(new ListCitiesQuery()));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var Countries = await Mediator.Send(new GetCountriesQuery());

            SelectList countries = new SelectList(Countries, "Id", "Name");

            ViewBag.countries = countries;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(City city)
        {
            var id = await Mediator.Send(new CreateCityCommand { Name = city.Name, CountryId = city.CountryId, IsCapital = city.isCapital, Population = city.Population });
            return Redirect($"/Cities/List/{id}");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            await Mediator.Send(new DeleteCityCommand { Id = id.Value });
            return Redirect("/Cities/List/");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var Countries = await Mediator.Send(new GetCountriesQuery());

            SelectList countries = new SelectList(Countries, "Id", "Name");

            ViewBag.countries = countries;
            return View(await Mediator.Send(new GetCityByIdQuery { Id = id.Value }));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(City city)
        {
            await Mediator.Send(new EditCityCommand { Id = city.Id, Name = city.Name, CountryId = city.CountryId, IsCapital = city.isCapital, Population = city.Population });
            return Redirect("/Cities/List/");
        }
        public async Task<IActionResult> Details(int?id)
        {
            
            return View(await Mediator.Send(new GetCityByIdQuery { Id = id.Value }));
        }
    }
}
