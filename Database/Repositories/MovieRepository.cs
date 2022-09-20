using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReviews.Database.Repositories;
using MovieReviews.Models;

namespace MovieReviews.Database
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _context;

        public MovieRepository(ApplicationContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //public Task<Movie> GetMovieByIdAsync(Guid id)
        //{
        //    return _context.Movie.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
        //}

        //public async Task<Movie> AddReviewToMovieAsync(Guid id, Review review)
        //{
        //    var movie = await _context.Movie.Where(m => m.Id == id).FirstOrDefaultAsync();
        //    movie.AddReview(review);
        //    await _context.SaveChangesAsync();
        //    return movie;
        //}

        //public Task<List<Movie>> GetAllMovies()
        //{
        //    return _context.Movie.ToListAsync();
        //}
    }
}