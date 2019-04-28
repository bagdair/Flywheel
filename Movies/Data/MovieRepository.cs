
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Movies.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesContext _context;

        public MovieRepository(MoviesContext context)
        {
            _context = context;
        }
        public async Task<Movie[]> GetAllMoviesAsync()
        {
            IQueryable<Movie> query = _context.Movies
                .OrderBy(t => t.Title);

            return await query.ToArrayAsync();
        }

        public async Task<Movie[]> GetAllMoviesByFilter(string filter)
        {
            IQueryable<Movie> query = _context.Movies
                .OrderBy(t => t.Title);

            query = query
                .Where(m => m.Year.ToString() == filter || m.Title.Contains(filter) || m.Genre.Contains(filter));

            return await query.ToArrayAsync();
        }

        public async Task<Movie> GetMovieAsync(int Id)
        {
            IQueryable<Movie> query = _context.Movies;

            query = query.Where(m => m.Id == Id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Movie[]> GetAllMoviesByHighRatings()
        {
            IQueryable<Movie> query = _context.Movies
                .OrderByDescending(m => m.Ratings)
                .ThenBy(m => m.Title)
                .Take(5);

            return await query.ToArrayAsync();

        }

        public async Task<Movie[]> GetAllMoviesByAvgRatings()
        {
            IQueryable<Movie> query = _context.Movies;
            query
              .GroupBy(g => g.UserId, r => r.Ratings)
              .Select(r => new
              {
                  UserId = r.Key,
                  Ratings = r.Average()
              });

            return await query.Take(5).ToArrayAsync();
        }


        public async Task<Movie> UpdateMovieRanking(Movie movie)
        {

            _context.Movies.Attach(movie);
            _context.Entry<Movie>(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return movie;

        }
    }
}