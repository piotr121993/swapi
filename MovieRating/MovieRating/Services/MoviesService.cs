using MovieRating.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieRating.Services
{
    public class MoviesService : IMoviesService
    {
        public MoviesService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<MoviesList> GetMovies()
        {
            var response = await HttpClient.GetAsync("https://swapi.dev/api/films/");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return await JsonSerializer.DeserializeAsync<MoviesList>(responseStream, options);
        }

        public async Task<Movie> GetMovie(string url)
        {
            var response = await HttpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            return await JsonSerializer.DeserializeAsync<Movie>(responseStream, options);
        }
    }
}
