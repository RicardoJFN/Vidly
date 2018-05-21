using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name ="Movie: ")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime ReleaseDate { get; set; } = DateTime.MinValue;

        [Display(Name ="Date Added: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number in Stock: ")]
        [Required]
        [Range(1, 20, ErrorMessage = "The field number in stock must be between 1 and 20")]
        public int Stock { get; set; } = 0;

        public Genre Genre { get; set; }

        [ForeignKey("Genre")]
        [Required]
        public int GenreId { get; set; }
    }
}