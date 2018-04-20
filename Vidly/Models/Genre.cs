using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name ="Genre: ")]
        public string Type { get; set; }
    }
}