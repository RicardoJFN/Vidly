using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        //GET: Create customer
        public ActionResult New()
        {
            List<MembershipType> list = _repo.GetMembershipTypes().ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = list
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                NewCustomerViewModel viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _repo.GetMembershipTypes()
                };

                return View("CustomerForm", viewModel);
            }


            if (customer.Id == 0)
                _repo.CreateCustomer(customer);
            else
                _repo.UpdateCustomer(customer);

            return RedirectToAction("Index", "Customer");
        }


        //GET: Customer by id
        public ActionResult Details(int id)
        {
            Customer customer = _repo.GetCustomerById(id);

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _repo.GetCustomerById(id);

            if (customer == null)
                return HttpNotFound();


            var newCustomerViewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _repo.GetMembershipTypes().ToList()
            };


            return View("CustomerForm", newCustomerViewModel);
        }
    }
}