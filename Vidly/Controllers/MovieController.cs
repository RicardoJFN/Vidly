using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
        public ActionResult Details(int id)
        {
            Movie movie = _repo.GetMovieById(id);
            return View(movie);
        }
    }
}