namespace Mission06_Watson.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

[Table("Categories")] // ✅ Matches SQLite table name
public class Categories
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ Auto-incremented primary key
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = string.Empty; // ✅ Matches `TEXT NOT NULL`

    public virtual ICollection<Movie>? Movies { get; set; } // ✅ FK reference in Movies table
}