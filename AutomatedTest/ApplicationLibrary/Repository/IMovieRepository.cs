using ApplicationLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetMovieAsync(Guid id);
        Task CreateMovieAsync(Movie employee);
    }
}
