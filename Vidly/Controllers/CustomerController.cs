using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        private VidlyRepository _repo;

        public CustomerController()
        {
            _repo = new VidlyRepository();
        }

        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = _repo.GetCustomers().ToList(); ;

            return View(customers);
        }


        public ActionResult Details(int id)
        {
            Customer customer = _repo.GetCustomerById(id);

            return View(customer);
        }
    }
}