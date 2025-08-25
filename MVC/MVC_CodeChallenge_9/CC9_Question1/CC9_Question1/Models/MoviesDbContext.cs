using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CC9_Question1.Models
{
    public class MoviesDbContext : DbContext
    {

        public MoviesDbContext() : base("MoviesDbConnection") { }

        public DbSet<Movie> Movies { get; set; }

    }
}