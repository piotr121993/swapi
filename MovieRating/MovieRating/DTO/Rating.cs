using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRating.DTO
{
    public class Rating
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string MovieUrl { get; set; }

        public int Score { get; set; }
    }
}