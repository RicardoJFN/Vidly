using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Models
{
    public class VidlyRepository
    {
        #region Movies
        public IEnumerable<Movie> GetMovies()
        {
            Movie Shrek = new Movie()
            {
                Id = 1,
                Name = "Shrek"
            };

            Movie WallE = new Movie()
            {
                Id = 2,
                Name = "Wall-E"
            };

            List<Movie> list = new List<Movie>
            {
                Shrek,
                WallE
            };

            return list;
        }

        public Movie GetMovieById(int id)
        {
            List<Movie> movies = GetMovies().ToList();

            return movies.SingleOrDefault(m => m.Id == id);
        }
        #endregion

        #region Customers
        
        public IEnumerable<Customer> GetCustomers()
        {
            Customer john = new Customer()
            {
                Id = 1,
                Name = "John Smith"
            };

            Customer mary = new Customer()
            {
                Id = 2,
                Name = "Mary Williams"
            };

            List<Customer> customers = new List<Customer>()
            {
                john,
                mary
            };

            return customers;
        }
        
        public Customer GetCustomerById(int id)
        {
            List<Customer> customers = GetCustomers().ToList();

            return customers.SingleOrDefault(c => c.Id == id);
        }

        
        #endregion



    }
}