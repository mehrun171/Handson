using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC9_Question2.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(100)]
        public string MovieName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }
        [Required]
        public string DirectorName { get; set; }
    }
}