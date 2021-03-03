using Microsoft.EntityFrameworkCore;

namespace MovieRating.DTO
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Rating> Ratings { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
