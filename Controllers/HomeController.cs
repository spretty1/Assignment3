using Assignment3.Models;
using Assignment3.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
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
        public IApplicationBuilder _app; 
        private IMovieRepository _repository;
        private MovieDbContext context { get; set; }


        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieDbContext con)
        {
            _logger = logger;
            _repository = repository;
            context = con; 
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
        public IActionResult MovieForm(Movie movie)
        {
            if(ModelState.IsValid)
            { 
                context.Movies.Add(movie);
                context.SaveChanges();
                return View("Confirmation", movie);
            }
            else
            {
                return View("MovieForm");
            }
        }
        //shows the user the movie collection excluding independence day
       [HttpGet]
        public IActionResult MovieList()
        {
            return View("MovieList", new MovieListViewModel
            {
                Movies = _repository.Movies.Where(r => r.Title != "Independence Day")
            });
        }

        //allows the user to delete a record
        public IActionResult Delete(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();

            return View("MovieList", new MovieListViewModel
            {
                Movies = _repository.Movies.Where(r => r.Title != "Independence Day")
            });
        }

        //sends the user to the edit form view to edit a movie, along with the movie info 
        [HttpGet]
        public IActionResult EditMovie(Movie movie)
        {

                //Bring in the schedule of availability
                return View("EditMovie", movie);
        }

        //saves what the user changed and updates the database
        [HttpPost]
        public IActionResult EditMoviePost(Movie movie)
        {
            context.Movies.Update(movie);

            context.SaveChanges();
            return View("MovieList", new MovieListViewModel
            {
                Movies = _repository.Movies.Where(r => r.Title != "Independence Day")
            });
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
