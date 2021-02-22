using ApplicationLibrary.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _context;

        public MovieRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync() =>await _context.Movies.ToListAsync();

        public async Task<Movie> GetMovieAsync(Guid id) => await _context.Movies
            .SingleOrDefaultAsync(e => e.Id.Equals(id));

        public async Task CreateMovieAsync(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            _context.Add(movie);
            await _context.SaveChangesAsync();
        }
    }
}
