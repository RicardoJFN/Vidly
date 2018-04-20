using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Models
{
    public class VidlyRepository: IDisposable
    {
        private ApplicationDbContext _context;

        public VidlyRepository()
        {
            _context = new ApplicationDbContext();
        }

        #region Movies
        public IEnumerable<Movie> GetMovies()
        {

            return _context.Movies.Include("Genre").ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include("Genre").FirstOrDefault(m => m.Id == id);
        }
        #endregion

        #region Customers
        
        public IEnumerable<Customer> GetCustomers()
        {

            return _context.Customers.Include("MembershipType").ToList();
        }
        
        public Customer GetCustomerById(int id)
        {
            //List<Customer> customers = GetCustomers().ToList();

            return _context.Customers.Include("MembershipType").SingleOrDefault(c => c.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        #endregion



    }
}