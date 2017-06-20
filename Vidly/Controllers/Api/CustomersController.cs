using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using System.Collections;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {

            // Manual Mapper
            return _context.Customers.Select(c => new CustomerDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsSubscribedToNewsletter = c.IsSubscribedToNewsletter,
                    MembershipTypeId = c.MembershipTypeId,
                    Birthdate = c.Birthdate

                }
            );
        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //Manual Mapper
            //var customers1 = _context.Customers.Where(c => c.Id == id);
            //var customerDo= customers1.Select(c => new CustomerDto()
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    IsSubscribedToNewsletter = c.IsSubscribedToNewsletter,
            //    MembershipTypeId = c.MembershipTypeId,
            //    Birthdate = c.Birthdate

            //}
            //);


            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            return customer;
        }

        // POST /api/customers
        [HttpPost]

        //public Customer PostCustomer(Customer customer) // if we  use this method we dont need to apply [HttpPost]
        public  Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            
            _context.Customers.Add(customer);
            _context.SaveChanges();


            return customer;
        }


        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}

//We test by using advance rest client add extention to chrome


