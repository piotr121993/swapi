using System.Text.Json.Serialization;

namespace MovieRating.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Url { get; set; }

        [JsonPropertyName("opening_crawl")]
        public string OpeningCrawl { get; set; }
    }
}
