using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CC9_Question1.Models
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