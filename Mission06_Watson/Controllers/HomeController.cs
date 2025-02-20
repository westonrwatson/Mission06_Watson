using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // ✅ Main Landing Page
        public IActionResult Index()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName"); // ✅ Ensure dropdown works
            var movies = _context.Movies
                .Include(m => m.Category) // ✅ Ensure Category names load
                .ToList();

            return View(movies);
        }
        
        // ✅ Get To Know Joel Page
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // ✅ Add Movie Page (GET)
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName"); // ✅ Ensure dropdown is populated
            return View();
        }

        // ✅ Add Movie (POST)
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Movie added successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(movie);
        }

        // ✅ Edit Movie (POST)
        [HttpPost]
        public IActionResult UpdateMovie([FromBody] Movie updatedMovie)
        {
            var movie = _context.Movies.Find(updatedMovie.MovieId);
            if (movie == null)
            {
                return NotFound();
            }

            // ✅ Update all fields properly
            movie.Title = updatedMovie.Title;
            movie.CategoryId = updatedMovie.CategoryId; // ✅ Assign CategoryId, not Category object
            movie.Year = updatedMovie.Year ?? 2000; // ✅ Handle null years
            movie.Director = updatedMovie.Director;
            movie.Rating = updatedMovie.Rating;
            movie.Edited = updatedMovie.Edited; // ✅ Default to false if null
            movie.CopiedToPlex = updatedMovie.CopiedToPlex; // ✅ Default to false if null

            // ✅ Explicitly set null if input is empty
            movie.LentTo = string.IsNullOrWhiteSpace(updatedMovie.LentTo) ? null : updatedMovie.LentTo;
            movie.Notes = string.IsNullOrWhiteSpace(updatedMovie.Notes) ? null : updatedMovie.Notes;

            _context.SaveChanges();
            return Ok();
        }

        // ✅ Delete Movie (POST)
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