using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CountryAPI.Models;

namespace CountryAPI.Controllers
{
    public class CountryController : ApiController
    {
        private AppDbContext db = new AppDbContext();
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(db.Countries.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpPost]
        public IHttpActionResult AddCountry(int ID, string CountryName, string Capital)
        {
            var country = new Country
            {
                ID = ID,
                CountryName = CountryName,
                Capital = Capital
            };

            db.Countries.Add(country);
            db.SaveChanges();
            return Ok(country);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Country updated)
        {
            var country = db.Countries.Find(id);
            if (country == null) return NotFound();
            if (updated == null)
                return BadRequest("No country data received.");

            country.CountryName = updated.CountryName;
            country.Capital = updated.Capital;
            db.SaveChanges();

            return Ok(country);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null) return NotFound();

            db.Countries.Remove(country);
            db.SaveChanges();
            return Ok();
        }
    }
}



    