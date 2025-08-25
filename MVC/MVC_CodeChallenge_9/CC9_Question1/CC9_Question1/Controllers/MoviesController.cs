using CC9_Question1.Models;
using CC9_Question1.Repository.Code_Challenge_9_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CC9_Question1.Controllers
{
    public class MovieController : Controller

    {

        private MovieRepository repo = new MovieRepository();

        public ActionResult MainPage() => View();

        public ActionResult Index() => View(repo.GetAll());

        public ActionResult Create() => View();

        [HttpPost]

        public ActionResult Create(Movie m)

        {

            repo.Add(m);

            return RedirectToAction("Index");

        }

        public ActionResult Edit() => View();

        [HttpPost]

        public ActionResult Edit(int id)

        {

            var movie = repo.GetById(id);

            if (movie == null)

            {

                ViewBag.Error = $"Movie with ID {id} not found.";

                return View();

            }

            return View(movie);

        }

        [HttpPost]

        public ActionResult Edit(Movie m)

        {

            repo.Update(m);

            ViewBag.Message = $"Movie with ID {m.Mid} updated.";

            return View("Edit", m);

        }

        public ActionResult Delete() => View();

        [HttpPost]

        public ActionResult Delete(int id)

        {

            var movie = repo.GetById(id);

            if (movie == null)

            {

                ViewBag.Error = $"Movie with ID {id} not found.";

                return View();

            }

            repo.Delete(id);

            ViewBag.Message = $"Movie with ID {id} deleted.";

            return View();

        }

        public ActionResult MoviesByYear(int year) =>

            View(repo.GetByYear(year));

        public ActionResult MoviesByDirector(string name)
        {
            return View("ByDirector", repo.GetByDirector(name));
        }

    }
}