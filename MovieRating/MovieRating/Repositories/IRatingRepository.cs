using MovieRating.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieRating.Repositories
{
    public interface IRatingRepository
    {
        void Add(Rating rating);
        Task<List<Rating>> GetAll(string movieUrl);
        Task SaveChanges();
    }
}