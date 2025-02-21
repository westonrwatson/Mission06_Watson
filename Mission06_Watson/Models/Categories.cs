namespace Mission06_Watson.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

// Set up to Match the new Categories Table

[Table("Categories")] // Matches SQLite table name
public class Categories
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = string.Empty; 

    public virtual ICollection<Movie>? Movies { get; set; }
}