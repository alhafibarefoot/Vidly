using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();


        }

        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

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

//asp.Net MVC
//client send reuest --->Server //server/iis/razorview back as markup HTML(Roue Data which generated in server)

//WEB API
//client send reuest --->data services WEB API(Application Program interface)--->server
//HTML generate in Client as Markup Data(XML or JASON(javascript serlized) ) which used plugin in client JQuery(datatavle, sorting, searching..etc)
//Benifit
//L1)ess resource of server
//2)Less Bandwidth
//3)support broadband of mobil(mobile, table, pc, laptop)


//Framework(1-asp.Net MVC 2-asp.Net WEB API) microsft merge toframe work in asp.Net Core

//REST-REpresental State Transfer
//GET --------api/Customer      ---get resource
//GET --------api/Customer/1    ---get resource for customerid=1
//POST -------api/Customer     ---Update resource
//PUT --------api/Customer/1    ---Update resource for customerid=1
//DELETE ---- api/Customer/1    ---Update resource for customerid=1


