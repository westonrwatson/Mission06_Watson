using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Watson.Models;

namespace Mission6_Watson.Controllers;

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
    
    // Add Movie Page
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }
    
    // Add Movie itself
    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Movie added successfully!";
        }

        return View(movie);
    }
    
}