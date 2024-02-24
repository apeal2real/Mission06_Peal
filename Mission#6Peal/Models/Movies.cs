using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission_6Peal.Models
{
    // Represents a movie entity
    public class Movies
    {
        // Primary key for the movie
        [Key]
        public int MovieId { get; set; }

        // Foreign key for category
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        // The title of the movie (required)
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        // The release year of the movie (required, must be greater than or equal to 1888)
        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888")]
        public int Year { get; set; }

        // The director of the movie
        public string? Director { get; set; }

        // The rating of the movie (required)
        [Required(ErrorMessage = "Rating is required")]
        public string Rating { get; set; }

        // Indicates whether the movie has been edited (required)
        [Required(ErrorMessage = "Edited is required")]
        public int? Edited { get; set; }

        // Indicates to whom the movie is lent
        public string? LentTo { get; set; }

        // Indicates whether the movie has been copied to Plex (required)
        [Required(ErrorMessage = "CopiedToPlex is required")]
        public int CopiedToPlex { get; set; }

        // Additional notes about the movie
        [StringLength(25)]
        public string? Notes { get; set; }
    }

    // Represents categories for movies
    public class Categories
    {
        // Primary key for the category
        [Key]
        public int CategoryId { get; set; }

        // The name of the category
        public string Category { get; set; }
    }
}
