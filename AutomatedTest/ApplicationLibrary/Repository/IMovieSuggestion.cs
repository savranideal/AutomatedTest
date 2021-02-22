using System;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public interface IMovieSuggestion
    {
        Task<bool> IsGoodMovieAsync(Guid movieId);
         
    }
}
