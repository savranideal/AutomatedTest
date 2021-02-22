using System;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class MovieScore : IMovieScore
    {
        private readonly IMovieRepository _movieRepository;
        public MovieScore(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<decimal> ScoreAsync(Guid movieId)
        {
            return (await _movieRepository.GetMovieAsync(movieId))?.ImdbRating ?? 0;
        }
    }
}
