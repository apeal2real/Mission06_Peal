using Microsoft.EntityFrameworkCore;

namespace Mission_6Peal.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) 
        { 
        }

        public DbSet<Movies> Movies { get; set; }
    }
}
