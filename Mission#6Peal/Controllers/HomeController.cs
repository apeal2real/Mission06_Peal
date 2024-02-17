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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetTo()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieInfo(Movies response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation");
        }
    }
}
