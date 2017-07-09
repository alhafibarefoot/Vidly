using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();    
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            //var customer = _context.Customers.SingleOrDefault(
            //    c => c.Id == newRental.CustomerId);
            //if (customer == null)
            //    return BadRequest("Invalid Cutomer ID");
            //above code is not happy path define var customer in single only happy path because I assume
            //this private api pass from enternal system widget such as data picker and even hacker need 
            //to pass throught with invalid it return error
            //so above code exdtend without meaning and could be use for public api
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);


            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList(); //same select * from movie where id in (1,2,3);

            foreach (var movie in movies)
            {
                

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
