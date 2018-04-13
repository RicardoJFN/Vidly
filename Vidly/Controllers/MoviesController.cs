using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyRepository _repo;

        public MoviesController()
        {
            _repo = new VidlyRepository();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            List<Movie> movies = _repo.GetMovies().ToList();

            return View(movies);
        }
    }
}