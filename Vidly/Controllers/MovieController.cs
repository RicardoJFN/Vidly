using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private VidlyRepository _repo;

        public MovieController()
        {
            _repo = new VidlyRepository();
        }


        [HttpGet]
        public ActionResult Index()
        {
            List<Movie> movies = _repo.GetMovies().ToList();

            return View(movies);
        }


        [HttpGet]
        public ActionResult New()
        {
            Movie newMovie = new Movie()
            {
                Stock = 0,
                ReleaseDate = DateTime.MinValue
            };

            var movieViewModel = new NewMovieViewModel()
            {
                Movie = newMovie,
                Genres = _repo.GetGenres()
            };

            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                Movie newMovie = new Movie()
                {
                    Stock = 0,
                    ReleaseDate = DateTime.MinValue
                };

                NewMovieViewModel viewModel = new NewMovieViewModel()
                {
                    Genres = _repo.GetGenres(),
                    Movie = newMovie
                };
                

                return View("New", viewModel);
            }

            if (movie.Id == 0)
                _repo.NewMovie(movie);
            else
                _repo.UpdateMovie(movie);


            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Movie movie = _repo.GetMovieById(id);
            return View(movie);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie movie = _repo.GetMovieById(id);

            var newMovieViewModel = new NewMovieViewModel()
            {
                Movie = movie,
                Genres = _repo.GetGenres()
            };

            return View(newMovieViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            _repo.UpdateMovie(movie);
            return RedirectToAction("Index", "Movie");
        }
    }
}