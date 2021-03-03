using Microsoft.AspNetCore.Mvc;
using MovieRating.Models;
using MovieRating.Repositories;
using MovieRating.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IMoviesService moviesService, IRatingRepository ratingRepository)
        {
            MoviesService = moviesService;
            RatingRepository = ratingRepository;
        }

        public IMoviesService MoviesService { get; }
        public IRatingRepository RatingRepository { get; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var movieList = await MoviesService.GetMovies();
            var viewModel = new MoviesViewModel
            {
                Movies = movieList.Results
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string movieUrl)
        {
            var movie = await MoviesService.GetMovie(movieUrl);
            var ratings = await RatingRepository.GetAll(movieUrl);
            var viewModel = new MovieViewModel
            {
               Title = movie.Title,
               OpeningCrawl = movie.OpeningCrawl,
               Scores = ratings.Select(r => r.Score)
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(string movieUrl, int score)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            RatingRepository.Add(new DTO.Rating
            {
                Id = Guid.NewGuid(),
                MovieUrl = movieUrl,
                Score = score
            });
            await RatingRepository.SaveChanges();

            var movie = await MoviesService.GetMovie(movieUrl);
            var ratings = await RatingRepository.GetAll(movieUrl);
            var viewModel = new MovieViewModel
            {
               Title = movie.Title,
               OpeningCrawl = movie.OpeningCrawl,
               Scores = ratings.Select(r => r.Score)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string selectedMovieUrl)
        {
            return RedirectToAction("Details", new { movieUrl = selectedMovieUrl });
        }
    }
}
