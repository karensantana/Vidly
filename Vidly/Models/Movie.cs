using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; } //*********************Include this class if you want to explore Genre model throught Movie model*******************************

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        
        public string DateAdded { get; set; }

        [Required]
        public string ReleasedDate { get; set; }

        [Required]
        public string NumberInStock { get; set; }

       
    }


}