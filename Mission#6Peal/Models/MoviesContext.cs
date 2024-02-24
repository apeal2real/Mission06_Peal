using Microsoft.EntityFrameworkCore;

namespace Mission_6Peal.Models
{
    // Represents the database context for managing movies and categories
    public class MoviesContext : DbContext
    {
        // Constructor that accepts DbContextOptions to configure the context
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        // Represents a DbSet for managing Movie entities in the database
        public DbSet<Movies> Movies { get; set; }

        // Represents a DbSet for managing Category entities in the database
        public DbSet<Categories> Categories { get; set; }
    }
}

