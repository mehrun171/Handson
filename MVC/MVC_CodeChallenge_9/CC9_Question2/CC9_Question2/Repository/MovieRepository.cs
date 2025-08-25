using CC9_Question2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CC9_Question2.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MoviesDbContext db = new MoviesDbContext();
        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public IEnumerable<Movie> GetByDirector(string directorName)
        {
            return db.Movies.Where(m => m.DirectorName == directorName).ToList();

        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            return db.Movies.Where(m => m.DateOfRelease.Year == year).ToList();
        }

        public void Update(Movie movie)
        {
            var mv = db.Movies.Find(movie.MovieId);
            if (mv != null)
            {
                mv.MovieName = movie.MovieName;
                mv.DirectorName = movie.DirectorName;
                mv.DateOfRelease = movie.DateOfRelease;
                db.SaveChanges();
            }
        }
    }
}