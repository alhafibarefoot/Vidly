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
            //What Edge case we have to face in rental api?
            //Customer ID is inValid
            //no MovieID
            //one or more movie are Invalid
            //one or more movie Not available


            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);


            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList(); //same select * from movie where id in (1,2,3);

            foreach (var movie in movies)
            {

                movie.NumberAvailable--;
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
