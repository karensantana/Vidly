using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Vidly.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class MovieViewModel
    {
       
        public IEnumerable<Genre> Genre { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

         //*********************Include this class if you want to explore Genre model throught Movie model*******************************

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Required]
        public string DateAdded { get; set; }

        [Required]
        public string ReleasedDate { get; set; }

        [Required]
        public string NumberInStock { get; set; }


        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;

        }
    }

    
}