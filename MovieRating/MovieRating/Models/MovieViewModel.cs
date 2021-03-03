using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRating.Models
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string OpeningCrawl { get; set; }
        public IEnumerable<int> Scores { get; set; }

        [Range(0, 10)]
        public int Score { get; set; }
    }
}
