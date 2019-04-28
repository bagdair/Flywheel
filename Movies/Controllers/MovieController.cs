using Movies.Data;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Movies.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private readonly IMovieRepository _repository;
        
        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        [Route()]
        public async Task<IHttpActionResult> GetMovies()
        {
            try
            {
                var result = await _repository.GetAllMoviesAsync();

                if (result.Length == 0) return NotFound();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            } 
        }
        [Route("{Id}")]
        public async Task<IHttpActionResult> GetMoviesById(int Id)
        {
            try
            {
                var result = await _repository.GetMovieAsync(Id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("moviesByFilter/{filter}")]
        [HttpGet]
        public async Task<IHttpActionResult> MoviesByFilter(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter)) return NotFound();

               var result = await _repository.GetAllMoviesByFilter(filter);

                if (result.Length == 0) return NotFound();


                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("moviesByHighRating")]
        [HttpGet]
        public async Task<IHttpActionResult> MoviesByHighRating()
        {
            try
            {
                var result = await _repository.GetAllMoviesByHighRatings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("moviesByAvgRating")]
        [HttpGet]
        public async Task<IHttpActionResult> MoviesByAvgRating()
        {
            try
            {    
                var result = await _repository.GetAllMoviesByAvgRatings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{Id}")]
        [HttpPut]
        public async Task<IHttpActionResult> Put(int Id)
        {
            try
            {

               Movie movie = await _repository.GetMovieAsync(Id);
               if (movie == null) return NotFound();
                
                var status = _repository.UpdateMovieRanking(movie);
                return Ok(status);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
