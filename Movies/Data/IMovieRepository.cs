using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data
{
    public interface IMovieRepository
    {
        Task<Movie[]> GetAllMoviesAsync();
        Task<Movie> GetMovieAsync(int Id);
        Task<Movie[]> GetAllMoviesByFilter(string filter);
        Task<Movie[]> GetAllMoviesByHighRatings();
        Task<Movie[]> GetAllMoviesByAvgRatings();       
        Task<Movie> UpdateMovieRanking(Movie movie);

    }
}
