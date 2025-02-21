namespace Mission06_Watson.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Setting up the movie database
public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Categories? Category { get; set; } 

    [Required(ErrorMessage = "Year is required.")]
    [Range(1888, 2100, ErrorMessage = "Enter a valid year.")]
    public int? Year { get; set; } 

    public string? Director { get; set; } 

    [Required(ErrorMessage = "Rating is required.")]
    public string Rating { get; set; } = "Not Rated"; 

    [Required]
    public bool Edited { get; set; } = false;

    public string? LentTo { get; set; } 

    [MaxLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    public string? Notes { get; set; } 

    [Required]
    public bool CopiedToPlex { get; set; } = false;
}