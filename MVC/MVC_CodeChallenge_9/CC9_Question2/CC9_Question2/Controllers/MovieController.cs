using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9_Question2.Models;
using CC9_Question2.Repository;

namespace CC9_Question2.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repository;

        public MovieController()

        {

            _repository = new MovieRepository();

        }

        public ActionResult Index()

        {

            var movies = _repository.GetAll();

            return View(movies);

        }

        public ActionResult Details(int id)

        {

            var movie = _repository.GetById(id);

            return View(movie);

        }

        public ActionResult Create()

        {

            return View();

        }

        [HttpPost]

        public ActionResult Create(Movie movie)

        {

            if (ModelState.IsValid)

            {

                _repository.Add(movie);

                return RedirectToAction("Index");

            }

            return View(movie);

        }

        public ActionResult Edit(int id)

        {

            var movie = _repository.GetById(id);

            return View(movie);

        }

        [HttpPost]

        public ActionResult Edit(Movie movie)

        {

            if (ModelState.IsValid)

            {

                _repository.Update(movie);

                return RedirectToAction("Index");

            }

            return View(movie);

        }


        [HttpGet]

        public ActionResult Delete(int id)

        {

            var movie = _repository.GetById(id);

            return View(movie);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Delete(Movie movie)

        {

            _repository.Delete(movie.MovieId);

            return RedirectToAction("Index");

        }

        public ActionResult SearchByYear()

        {

            return View();

        }

        [HttpPost]

        public ActionResult SearchByYear(int year)

        {

            return RedirectToAction("MoviesByYear", new { year });

        }

        public ActionResult MoviesByYear(int year)

        {

            var movies = _repository.GetByYear(year);

            ViewBag.Year = year;

            return View(movies);

        }

        public ActionResult SearchByDirector()

        {

            return View();

        }

        [HttpPost]

        public ActionResult SearchByDirector(string directorName)

        {

            return RedirectToAction("MoviesByDirector", new { directorName });

        }

        public ActionResult MoviesByDirector(string directorName)

        {

            var movies = _repository.GetByDirector(directorName);

            ViewBag.Director = directorName;

            return View(movies);

        }

    }

}