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

            //Definsive VS Optimistic

            //****************Definsive Approch
            //helpfull when you use public api used by differant application and different teams
            //for enternal use I prefer optimistic less condiftion less validation

            if (newRental.MovieIds.Count == 0)
                return BadRequest("no MovieID have been given"); //we move up because no movie so nesseccary quary customer

            var customer = _context.Customers.SingleOrDefault(
               c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Invalid Cutomer ID");

           

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList(); //same select * from movie where id in (1,2,3);

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("one or more movieIds are Invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                    return BadRequest("one or more movie Not available");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            //**************

            //****************Optimistic Approch

            //var customer = _context.Customers.Single(
            //    c => c.Id == newRental.CustomerId);


            //var movies = _context.Movies.Where(
            //    m => newRental.MovieIds.Contains(m.Id)).ToList(); //same select * from movie where id in (1,2,3);

            //foreach (var movie in movies)
            //{

            //    movie.NumberAvailable--;
            //    var rental = new Rental
            //    {
            //        Customer = customer,
            //        Movie = movie,
            //        DateRented = DateTime.Now
            //    };

            //    _context.Rentals.Add(rental);
            //}

            //**************

            

            _context.SaveChanges();

            return Ok();
        }
    }
}
