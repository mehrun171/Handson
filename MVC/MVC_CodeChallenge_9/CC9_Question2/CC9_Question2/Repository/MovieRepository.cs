using CC9_Question2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC9_Question2.Repository
{
    public class MovieRepository
    {
        private MoviesDbContext db = new MoviesDbContext();

        public IEnumerable<Movie> GetAll() => db.Movies.ToList();

        public Movie GetById(int id) => db.Movies.Find(id);

        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            var mv = db.Movies.Find(movie.Mid);
            if (mv != null)
            {
                mv.Moviename = movie.Moviename;
                mv.DirectorName = movie.DirectorName;
                mv.DateofRelease = movie.DateofRelease;
            }
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
            }
        }

        public IEnumerable<Movie> GetByYear(int year) =>
            db.Movies.Where(m => m.DateofRelease.Year == year).ToList();

        public IEnumerable<Movie> GetByDirector(string director) =>
            db.Movies.Where(m => m.DirectorName == director).ToList();
    }
}