using Microsoft.EntityFrameworkCore;
using MovieRating.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        public RatingRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public DatabaseContext DatabaseContext { get; }

        public async Task<List<Rating>> GetAll(string movieUrl)
        {
            return await DatabaseContext.Ratings.Where(r => r.MovieUrl == movieUrl).ToListAsync();
        }

        public void Add(Rating rating)
        {
            DatabaseContext.Ratings.Add(rating);
        }

        public async Task SaveChanges()
        {
            await DatabaseContext.SaveChangesAsync();
        }

    }
}
