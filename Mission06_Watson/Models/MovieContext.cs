namespace Mission06_Watson.Models;

using Microsoft.EntityFrameworkCore;
    
// Getting and setting values in the database

using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Categories> Categories { get; set; } // ✅ Correct table name

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // REMOVED SEED DATA (to prevent errors)
    }
}
