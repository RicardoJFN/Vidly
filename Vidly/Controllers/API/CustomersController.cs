using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private VidlyRepository _repo;

        public CustomersController()
        {
            _repo = new VidlyRepository();
        }
        //GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _repo.GetCustomers().ToList();
        }


        // GET /api/customers /1 
        public Customer GetCustomer(int id)
        {
            Customer customer = _repo.GetCustomerById(id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return customer;
        }

        //POST  /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _repo.CreateCustomer(customer);

            return customer;
        }

        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer customerInDb = _repo.GetCustomerById(id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _repo.UpdateCustomer(customerInDb);
        }


        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            Customer customer = _repo.GetCustomerById(id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _repo.DeleteCustomer(customer);
        }
    }
}
