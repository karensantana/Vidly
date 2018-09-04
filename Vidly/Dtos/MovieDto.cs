using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        
        [Required]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }

        public string DateAdded { get; set; }

        [Required]
        public string ReleasedDate { get; set; }

        [Required]
        public string NumberInStock { get; set; }
    }
}