using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Models
{
    public class VidlyRepository
    {

        public IEnumerable<Movie> GetMovies()
        {
            Movie Shrek = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };

            List<Movie> list = new List<Movie>
            {
                Shrek
            };

            return list;
        }


    }
}