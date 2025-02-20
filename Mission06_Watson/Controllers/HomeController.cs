using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Watson.Models;

namespace Mission06_Watson.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieContext _context;

        public HomeController(MovieContext context)
        {
            _context = context;
        }

        // Main Landing Page
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // Get To Know Joel Page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Add Movie Page (GET)
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        // Add Movie (POST)
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Movie added successfully!";
                return RedirectToAction("Index"); // Redirect to Index after adding
            }

            return View(movie);
        }

        // Edit Movie (POST)
        [HttpPost]
        public IActionResult UpdateMovie([FromBody] Movie updatedMovie)
        {
            var movie = _context.Movies.Find(updatedMovie.MovieId);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = updatedMovie.Title;
            movie.Category = updatedMovie.Category;
            movie.Year = updatedMovie.Year;
            movie.Director = updatedMovie.Director;
            movie.Rating = updatedMovie.Rating;
            movie.Edited = updatedMovie.Edited;

            // Explicitly set null if input is empty
            movie.LentTo = string.IsNullOrWhiteSpace(updatedMovie.LentTo) ? null : updatedMovie.LentTo;
            movie.Notes = string.IsNullOrWhiteSpace(updatedMovie.Notes) ? null : updatedMovie.Notes;

            _context.SaveChanges();
            return Ok();
        }

        // Delete Movie (Post)
        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
