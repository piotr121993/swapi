using MovieRating.Models;
using System.Threading.Tasks;

namespace MovieRating.Services
{
    public interface IMoviesService
    {
        Task<Movie> GetMovie(string url);
        Task<MoviesList> GetMovies();
    }
}