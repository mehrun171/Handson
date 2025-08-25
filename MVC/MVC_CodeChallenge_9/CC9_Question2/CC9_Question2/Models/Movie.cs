using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC9_Question2.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        [Required]
        public string Moviename { get; set; }

        [Required]
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofRelease { get; set; }
    }
}