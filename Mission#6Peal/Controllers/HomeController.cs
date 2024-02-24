using Microsoft.AspNetCore.Mvc;
using Mission_6Peal.Models;
using System.Diagnostics;

namespace Mission_6Peal.Controllers
{
    public class HomeController : Controller
    {

        private MoviesContext _context;
        public HomeController(MoviesContext temp)
        {
            _context = temp;
        }

        // Action method for rendering the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action method for rendering a view
        public IActionResult GetTo()
        {
            return View();
        }

        // Action method for rendering the movie information page (GET)
        [HttpGet]
        public IActionResult MovieInfo()
        {
            // Fetch categories to populate dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View(new Movies());
        }

        // Action method for handling movie information form submission (POST)
        [HttpPost]
        public IActionResult MovieInfo(Movies response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation");
            }
            else
            {
                // If model state is invalid, reload the form with validation errors
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();

                return View(response);
            }

        }

        // Action method for rendering the list of movies
        public IActionResult ShowMovies()
        {
            // Fetch categories to populate dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            // Fetch movies and render the view with them
            var movies = _context.Movies
                                .OrderBy(x => x.MovieId)
                                .ToList();

            return View(movies);
        }

        // Action method for rendering the edit movie form (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Fetch the movie to be edited
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            // Fetch categories to populate dropdown
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            // Render the movie info view with data for editing
            return View("MovieInfo", recordToEdit);
        }

        // Action method for handling movie edit form submission (POST)
        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            // Update the movie record in the database
            _context.Update(updatedInfo);
            _context.SaveChanges();

            // Redirect to the movie info page
            return RedirectToAction("MovieInfo");
        }

        // Action method for rendering the delete confirmation page (GET)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Fetch the movie to be deleted
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            // Render the delete confirmation view
            return View(recordToDelete);
        }

        // Action method for handling movie delete confirmation submission (POST)
        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            // Remove the movie record from the database
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            // Redirect to the list of movies
            return RedirectToAction("ShowMovies");
        }
    }
}
