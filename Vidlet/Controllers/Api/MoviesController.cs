using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Vidlet.Dtos;
using Vidlet.Models;

namespace Vidlet.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            //Gets IEnumerable list of MovieDtos from database. Includes Genre information 
            //Returns JSON Data of MoviesDtos.

             var moviesQuery =_context.Movies
                .Include(c => c.Genre);


             if (!String.IsNullOrWhiteSpace(query))
                 moviesQuery = moviesQuery.Where(m => m.Name.Contains(query)).Where(m => m.NumberAvailable > 0);

            var moviesDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

             return Ok(moviesDto);
        }

        public IHttpActionResult GetMovie(int id)
        {
            //Locates the movie from Id passed in.
            //Checks if id is valid
            //Returns a MovieDto of item.

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            //Checks if the incoming movieDto has a valid modelstate.
            //Maps the movieDto to movie object.
            //Adds the movie to application database.
            //Returns URI of movieDto with added in ID. 

            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {   

            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
