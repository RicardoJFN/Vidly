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

        public void NewMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            Movie existingMovie = GetMovieById(movie.Id);
            existingMovie.Name = movie.Name;
            existingMovie.ReleaseDate = movie.ReleaseDate;
            existingMovie.GenreId = movie.GenreId;
            existingMovie.Stock = movie.Stock;

            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Include("Genre").FirstOrDefault(m => m.Id == id);
        }
        #endregion

        #region Customers

        public void CreateCustomer(Customer customer){
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        
        public void UpdateCustomer(Customer customer)
        {
            Customer existingCustomer = GetCustomerById(customer.Id);

            existingCustomer.Name = customer.Name;
            existingCustomer.Birthdate = customer.Birthdate;
            existingCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            existingCustomer.MembershipTypeId = customer.MembershipTypeId;
            existingCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {

            return _context.Customers.Include("MembershipType").ToList();
        }
        
        public Customer GetCustomerById(int id)
        {
            //List<Customer> customers = GetCustomers().ToList();

            return _context.Customers.Include("MembershipType").SingleOrDefault(c => c.Id == id);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);

            _context.SaveChanges();
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        #endregion



    }
}