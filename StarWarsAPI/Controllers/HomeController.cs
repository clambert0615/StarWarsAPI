using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsAPI.Models;

namespace StarWarsAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StarWarsDAL SD = new StarWarsDAL();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            People p = SD.GetPeople();
            
            return View(p);
            
        }
        public IActionResult PersonSearch(int Id)
        {
            Person p = SD.GetPerson("people", Id);
            return View(p);
        }
        public IActionResult PlanetSearch(int Id)
        {
            Planet pl = SD.GetPlanet("planets", Id);
                return View(pl);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
