using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //set the action to access the index view 
        public IActionResult Index()
        {
            return View();
        }
        //set the action to access the podcasts view 
        public IActionResult MyPodcasts()
        {
            return View();
        }
        //set the action to access the movie form view when the user is requesting it
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        //set the action to access the movie form view for posting information, sends user to confirmation page 
        [HttpPost]
        public IActionResult MovieForm(MovieCollection appResponse)
        {
            if(ModelState.IsValid)
            { 
                TempStorage.AddMovie(appResponse);

                return View("Confirmation", appResponse);
            }
            else
            {
                return View("MovieForm");
            }
        }
        //shows the user the movie collection excluding independence day
        public IActionResult MovieList()
        {
            return View(TempStorage.Movies.Where(r => r.Title != "Independence Day" ));
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
