using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CountryAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public AppDbContext() : base("name=connectstr") { }
    }
}