using Microsoft.AspNetCore.Mvc;
using MovieRating.Controllers;
using MovieRating.DTO;
using MovieRating.Models;
using MovieRating.Repositories;
using MovieRating.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovieRating.Tests
{
    public class HomeControllerFacts
    {
        public class DetailsMethod
        {
            public IMoviesService MoviesService { get; }
            public IRatingRepository RatingRepository { get; }

            public HomeController HomeController { get; }

            public DetailsMethod()
            {
                MoviesService = Substitute.For<IMoviesService>();
                RatingRepository = Substitute.For<IRatingRepository>();

                HomeController = new HomeController(MoviesService, RatingRepository);
            }

            [Fact]
            public async Task ReturnsViewWithMovieViewModel()
            {
                //Arrange
                const string movieUrl = "https://test.test/api/film/1";
                const string title = "Test movie title";
                const string openingCrawl = "lorem ipsum";
                var scores = new[] { 7, 4 };

                var movie = new Movie
                {
                    Url = movieUrl,
                    OpeningCrawl = openingCrawl,
                    Title = title
                };
                var ratings = scores.Select(s => new Rating
                {
                    Id = Guid.NewGuid(),
                    MovieUrl = movieUrl,
                    Score = s
                }).ToList();

                RatingRepository.GetAll(movieUrl).Returns(ratings);
                MoviesService.GetMovie(movieUrl).Returns(movie);

                //Act
                var result = await HomeController.Details(movieUrl);

                //Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<MovieViewModel>(viewResult.ViewData.Model);
                Assert.Equal(movie.Title, model.Title);
                Assert.True(model.Scores.SequenceEqual(scores));
                Assert.Equal(title, model.Title);
            }
        }
    }
}
