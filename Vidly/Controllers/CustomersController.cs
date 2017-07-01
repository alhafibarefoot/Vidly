using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;   /*This used in eager to include forign key*/

namespace Vidly.Controllers
{
    [Authorize] //all method should be authorized 
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize] //Only this method authorized
        public ViewResult Index()
        {
            
            return View();
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); /*Eager*/

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //We add this New view when we submit hidden Id return error in validation summery because it post string value by adding this Id=0
                MembershipTypes = membershipTypes
            };
            
            return View("CustomerForm", viewModel); /*we add CustomerForm in View(viewModel)  because name of view differance than action=New */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)  /*MVC smart enough to know all attributes +forighn keys*/
        {
            if (!ModelState.IsValid) //the passing binding is valid Model=Customer met needs such as annototation  [required] [StringLength(255)]
            {
                var viewModel = new CustomerFormViewModel //if not valid return to same form by reverse data whch posted from form
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); //choose single instead of singleordefulat , because if there is customer not found it througn error I will not handle error
                //TryUpdateModel(customerInDb); 
                //we can use TryUpdateModel officilly Nice and advice from microsoft instead below line to update form
                //but it update all pass from form lead to security hole
                //We can update partial of form 
                //TryUpdateModel(customerInDb,"",new string[] {"Name","Email" }); 
                //but problem in majic word 

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel); 
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }
    }
}

