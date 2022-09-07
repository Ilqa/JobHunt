using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieReviews.Models;

namespace MovieReviews.Database
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieByIdAsync(Guid id);
        Task<List<Movie>> GetAllMovies();


        Task<Movie> AddReviewToMovieAsync(Guid id, Review review);
    }
}