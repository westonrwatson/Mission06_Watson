namespace Mission06_Watson.Models;

using Microsoft.EntityFrameworkCore;
    
// Getting and setting values in the database

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }

    // pre seeding the database with movies
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 1,
                Category = "Sci-Fi",
                Title = "Inception",
                Year = "2010",
                Director = "Christopher Nolan",
                Rating = "PG-13",
                Edited = false,
                LentTo = "John",
                Notes = "Mind-bending thriller"
            },
            new Movie
            {
                MovieId = 2,
                Category = "Sci-Fi",
                Title = "The Matrix",
                Year = "1999",
                Director = "The Wachowskis",
                Rating = "R",
                Edited = true,
                LentTo = "Sarah",
                Notes = "Classic cyberpunk"
            },
            new Movie
            {
                MovieId = 3,
                Category = "Sci-Fi",
                Title = "Interstellar",
                Year = "2014",
                Director = "Christopher Nolan",
                Rating = "PG-13",
                Edited = false,
                LentTo = "Michael",
                Notes = "Epic space journey"
            }
        );
    }
}