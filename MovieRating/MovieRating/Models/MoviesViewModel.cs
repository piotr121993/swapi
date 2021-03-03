using System.Collections.Generic;

namespace MovieRating.Models
{
    public class MoviesViewModel
    {
        public string SelectedMovieUrl { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
