namespace Mission06_Watson.Models;

using System.ComponentModel.DataAnnotations;

// Setting up the movie database

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, 2100, ErrorMessage = "Enter a valid year.")]
    public string Year { get; set; }

    [Required(ErrorMessage = "Director is required.")]
    public string Director { get; set; }

    [Required(ErrorMessage = "Rating is required.")]
    public string Rating { get; set; }

    public bool Edited { get; set; }

    public string? LentTo { get; set; }

    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; }
}
