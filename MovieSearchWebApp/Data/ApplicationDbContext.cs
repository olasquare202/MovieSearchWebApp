using Microsoft.EntityFrameworkCore;
using MovieSearchWebApp.Models;

namespace MovieSearchWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> movies { get; set; }
    }
}
