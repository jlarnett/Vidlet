using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidlet.Dtos;
using Vidlet.Models;

namespace Vidlet.Controllers.Api
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

            //Check that some movieIds were included
            //Get Customer object from database
            //Verify Customer is not null
            //Get List of movies from database.
            //Verify that the number of movies received from database match incoming amount.

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies
                .Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movieIds are invalid.");



            foreach (var movie in movies)
            {
                if (movie.NumberAvailable <= 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
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
