using CC9_Question2.Models;
using CC9_Question2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC9_Question2.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRepository repo = new MovieRepository();

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                return RedirectToAction("List");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }
        
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("List");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var movies = repo.GetAll();
            return View(movies);
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string director)
        {
            var movies = repo.GetByDirector(director);
            return View(movies);
        }
    }
}