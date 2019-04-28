using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        public int Id { get; set; }  
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        public decimal Price { get; set; }
        [Required]
        public string Genre { get; set; }

        [Range(1,5)]
        public int Ratings { get; set; }

        public int UserId { get; set; }
                   

    }
}