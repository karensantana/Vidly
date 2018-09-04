using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies 
        public IEnumerable <MovieDto> GetMovies()
        {
            return _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }
        //GET /api/movie/id
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return BadRequest();
            return Ok();
        }
        //POST /api/movie 
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri +"/"+ movie.Id), movieDto );

        }

        //PUT /api/movie/id
        public IHttpActionResult UpdateMovie (int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest); //throw new HttpResponseException HttpCode.BadRequest every time the model is not valid.
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound); //throw new HttpResponseException HttpCode.Not Found if the obect is not found.

            Mapper.Map(movieDto, movie); //Is not needed to edit each property of the object because the mapper tracks changes of the object.
            _context.SaveChanges();
            return Ok();

        }

        //DELETE /api/movie/id
        public IHttpActionResult DeleteMovie (int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }
    }
}
