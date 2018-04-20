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
        public string Name { get; set; }

        [Display(Name = "Release Date: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, MMMM d, yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name ="Date Added: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, MMMM d, yyyy}")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock: ")]
        public int Stock { get; set; }

        public Genre Genre { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
    }
}