using CC9_Question1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC9_Question1.Repository
{
    namespace Code_Challenge_9_MVC.Repository

    {

        public class MovieRepository

        {

            private MoviesDbContext db = new MoviesDbContext();

            public List<Movie> GetAll() => db.Movies.ToList();

            public Movie GetById(int id) => db.Movies.FirstOrDefault(m => m.Mid == id);

            public void Add(Movie m)

            {

                db.Movies.Add(m);

            }

            public void Update(Movie m)

            {

                db.Entry(m).State = System.Data.Entity.EntityState.Modified;

            }

            public void Delete(int id)

            {

                var movie = db.Movies.FirstOrDefault(m => m.Mid == id);

                if (movie != null)

                {

                    db.Movies.Remove(movie);

                }

            }

            public List<Movie> GetByYear(int year) =>

                db.Movies.Where(m => m.DateofRelease.Year == year).ToList();

            public List<Movie> GetByDirector(string name) =>

                db.Movies.Where(m => m.DirectorName == name).ToList();

        }

    }

}

 